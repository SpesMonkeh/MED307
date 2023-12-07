using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    /*
     * 1.
     * 
     * Opret eventuelt et MonoBehaviour script, f.eks. WordPanel, smæk det på et GameObject og lav det til en prefab, som
     * placeres i Assets/Prefabs/Resources/UI
     * Hent prefab'en i Awake() vha. Resources.Load<WordPanel>( NAVN PÅ PREFAB FIL ) og opbevar i en variabel, WordPanel wordPanelPrefab, maybe.
     *
     * Hver gang en ny CompendiumEntry samles op => newEntry = Instantiate(wordPanelPrefab, parent: transform)
     * Giv newEntry det opsamlede CompendiumEntry ScriptableObject, så newEntry kan læse den Texture, som opbevares i SO'en
     * tilføj newEntry til en liste, wordPanels, måske?
     *
     * WordPanel kan indeholde en metode, som tænder og slukker for det UI komponenter eller child-GOs.
     */
    [SerializeField] private GameObject[] _wordPanels;

    private void OnTriggerEnter(Collider other)
    {
        /*
         * At sammenligne to strings er dyrt på længere sigt.
         * Hvis det er en string, som aldrig ændres; opbevar som konstant, f.eks: const string PLAYER_OBJ_NAME og brug konstanten nede i koden.
         * Så undgås magic strings.
         * Et andet problem er, at vi, som det er nu, antager, at det spiller-kontrollede gObj med sikkerhed vil hedde "Player".
         * Vi antager også, at et gameObj med det navn, er styret af spilleren.
         * Vores projekt er selvfølgelig for småt til, at det har den store betydning
         *
         * Dét, jeg ville gøre er:
         * 
         *      if (other.gameObject.TryGetComponent(out PlayerBehaviour playerObj) is false)
         *          return;
         *
         *      ...
         *
         * TryGetComponent returnerer en bool som er TRUE hvis playerObj != NULL
         * Hvis FALSE; bare vend om.
         * 
         */
        if (other.gameObject.name == "Player")  
        {
            /*
             * Er ret sikker på, at metoden ikke bliver fuldført, hvis dets gameObj selvdestruerer inden, al koden, i metoden, er eksekveret.
             * Med andre ord: Alt under Destroy(transform.gameObject) er nok død kode.
             *
             * I stedet for Destroy(), så bare sluk gameObject via SetActive.
             */
            Destroy(transform.gameObject);
            
            /*
             * Magic strings. Øv.
             * Hvis wordPanels-gameObject'erne er UI objekter fra et andet gameObj med et Canvas, så hører det ikke umiddelbart til i ItemBehaviour,
             * men måske i Compendium eller et relaterende script.
             * Det script kunne indeholde en Dictionary<CompendiumEntry, WordPanel>
             * eller Dictionary<CompendiumAction, WordPanel> og Dictionary<CompendiumSign, WordPanel>
             *
             * Vi kan bruge en event til at aktivere et wordPanel i et andet gameObj.
             * I stedet for at lave en ny Action event, kan Compendium._playerPickup modificeres:
             *
             *      I Compendium.cs:
             *          public static Action _playerPickUp = delegate {  };
             *
             *      Ændres til:
             *          public static Action<CompendiumEntry> _playerPickup = delegate {  };
             *
             * Det betyder, at, når eventen kaldes, skal en CompendiumEntry instance inkluderes:
             *
             *      Compendium._playerPickup?.Invoke( CompendiumEntry VARIABEL );
             *
             * Denne CompendiumEntry variabel kunne opbevares i et SerializedField i dette script. Så hvis dette er ItemBehaviour for tegnet A,
             * så giv det det tilhørende CompendiumSign ScriptableObject.
             * 
             * De abonnerende metoder ( += ), i andre klasser, som subscriber til _playerPickup,
             * skal nu også tage et argument af typen CompendiumEntry, f.eks:
             *
             *      void OnEnable()
             *      {
             *          Compendium._playerPickup += ExampleMethod;
             *      }
             *
             *      void ExampleMethod(CompendiumEntry entry)
             *      {
             *          ...
             *      }
             *
             * Husk at unsubscribe i OnDisable()
             */
            if (CompareTag("A"))
            {
                _wordPanels[0].SetActive(true);
                Compendium._playerPickUp?.Invoke();
            }
            else if(CompareTag("B"))
            {
                _wordPanels[1].SetActive(true);
                Compendium._playerPickUp?.Invoke();
            }
            else if (CompareTag("D"))
            {
                _wordPanels[2].SetActive(true);
                Compendium._playerPickUp?.Invoke();
            }
            
            Debug.Log("Item Collected");
            
        }
    }
}
