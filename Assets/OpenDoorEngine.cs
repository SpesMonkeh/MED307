using System.Collections.Generic;
using Unity.Sentis;
using UnityEngine;

public class OpenDoorEngine : MonoBehaviour
{
    [SerializeField] ModelAsset onnxAsset;

    Ops ops;
    Model model;
    Camera lookCamera;
    TensorFloat inputTensor;
    IWorker engine;

    static BackendType backendType = BackendType.GPUCompute;

    const int IMAGE_WIDTH = 640;
    const int IMAGE_HEIGHT = 480;

    void Start()
    {
        this.model = ModelLoader.Load(this.onnxAsset);
        engine = WorkerFactory.CreateWorker(backendType, model);
        ops = WorkerFactory.CreateOps(backendType, null);
        lookCamera = Camera.main;
    }

    // Sends the image to the neural network model and returns the probability that the image is each particular digit.
    public (float, int) GetMostLikelyGestureProbability(Texture2D drawableTexture)
    {
        this.inputTensor?.Dispose();

        // Convert the texture into a tensor, it has width=W, height=W, and channels=1:    
        this.inputTensor = TextureConverter.ToTensor(drawableTexture, IMAGE_WIDTH, IMAGE_HEIGHT, 3);
        
        // run the neural network:
        this.engine.Execute(this.inputTensor);
        
        // We get a reference to the output of the neural network while keeping it on the GPU
        TensorFloat result = this.engine.PeekOutput() as TensorFloat;
        
        // convert the result to probabilities between 0..1 using the softmax function:
        var probabilities = ops.Softmax(result);
        var indexOfMaxProbability = ops.ArgMax(probabilities, -1, false);
        
        // We need to make the result from the GPU readable on the CPU
        probabilities.MakeReadable();
        indexOfMaxProbability.MakeReadable();

        var predictedNumber = indexOfMaxProbability[0];
        var probability = probabilities[predictedNumber];

        return (probability, predictedNumber);
    }

    // Clean up all our resources at the end of the session so we don't leave anything on the GPU or in memory:
    private void OnDestroy()
    {
        inputTensor?.Dispose();
        engine?.Dispose();
        ops?.Dispose();
    }

}
