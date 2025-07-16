using System;
using Unity.Sentis;
using UnityEngine;

namespace P307.Runtime.ComputerVision
{
	[DisallowMultipleComponent]
	public sealed class Engine : MonoBehaviour
	{
		[SerializeField] ModelAsset onnxAsset;
		[SerializeField] BackendType backendType = BackendType.GPUCompute;
		Ops ops;
		Model model;
		Camera lookCamera;
		TensorFloat inputTensor;
		TensorFloat outputTensor;
		IWorker engine;

		const int IMAGE_WIDTH = 640;
		const int IMAGE_HEIGHT = 480;

		void Start()
		{
			this.model = ModelLoader.Load(this.onnxAsset);
			this.engine = WorkerFactory.CreateWorker(backendType, this.model);
			this.ops = WorkerFactory.CreateOps(backendType, null);
			this.lookCamera = Camera.main;
		}

		// Sends the image to the neural network model and returns the probability that the image is each particular digit.
		public (float, int) GetMostLikelyGestureProbability(Texture2D drawableTexture)
		{
			this.inputTensor?.Dispose();

			// Convert the texture into a tensor, it has width=W, height=W, and channels=3:    
			this.inputTensor = TextureConverter.ToTensor(drawableTexture, IMAGE_WIDTH, IMAGE_HEIGHT, 3);
			
			this.engine.Execute(this.inputTensor);

			// We get a reference to the output of the neural network while keeping it on the GPU
			var result = this.engine.PeekOutput() as TensorFloat;

			// convert the result to probabilities between 0..1 using the softmax function:
			var probabilities = this.ops.Softmax(result);
			var indexOfMaxProbability = this.ops.ArgMax(probabilities, -1, false);

			// We need to make the result from the GPU readable on the CPU
			probabilities.MakeReadable();
			indexOfMaxProbability.MakeReadable();

			var predictedNumber = indexOfMaxProbability[0];
			var probability = probabilities[predictedNumber];

			return (probability, predictedNumber);
		}
		
		// Clean up all our resources at the end of the session so we don't leave anything on the GPU or in memory:
		void OnDestroy()
		{
			this.inputTensor?.Dispose();
			this.engine?.Dispose();
			this.ops?.Dispose();
		}
	}
}