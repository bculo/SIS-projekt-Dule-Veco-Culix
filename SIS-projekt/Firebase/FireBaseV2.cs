using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_projekt
{
    class FireBaseV2
    {
        private static FireBaseV2 instanca;

        public static FireBaseV2 GetFireBase2
        {
            get
            {
                return instanca ?? (instanca = new FireBaseV2());
            }
        }

        public FirebaseClient client;

        /// <summary>
        /// Spoji se na firebejs
        /// </summary>
        private FireBaseV2()
        {
            client = new FirebaseClient(StatickeVarijable.FIREBASE_PATH,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(StatickeVarijable.FIREBASE_AUTH)
                });
        }

        /// <summary>
        /// Dohvati aktivne korisnike 
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<FirebaseKorisnik>> DohvatiAktivneKorisnike()
        {
            try
            {
                var response = await client
                    .Child(StatickeVarijable.FIREBASE_MAIN_NODE)
                    .OnceAsync<FirebaseKorisnik>();

                return DohvatiObservableCollection(response);
            }
            catch (Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
                return null;
            }
        }

        /// <summary>
        /// Dohvati ObservableCollection FirebaseKorisnik
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private ObservableCollection<FirebaseKorisnik> DohvatiObservableCollection(IReadOnlyCollection<FirebaseObject<FirebaseKorisnik>> response)
        {
            ObservableCollection<FirebaseKorisnik> tempLista = new ObservableCollection<FirebaseKorisnik>();

            foreach (var user in response)
            {
                FirebaseKorisnik firebaseKorisnik = user.Object;
                firebaseKorisnik.KljucFirebase = user.Key;
                tempLista.Add(user.Object);
            }

            return tempLista;
        }

        /// <summary>
        /// Oznaci aktivnost na firebasu
        /// </summary>
        /// <returns></returns>
        public async Task<Boolean> OznaciAktivnostNaFireBejsu()
        {
            try
            {
                TrenutniKorisnik.FirebaseKorisnik = new FirebaseKorisnik(TrenutniKorisnik.Korisnik.KorisnickoIme,
                    TrenutniKorisnik.Korisnik.Port, TrenutniKorisnik.Korisnik.JavniKljuc);

                var response = await client
                  .Child(StatickeVarijable.FIREBASE_MAIN_NODE)
                  .PostAsync(JsonConvert.SerializeObject(TrenutniKorisnik.FirebaseKorisnik));

                TrenutniKorisnik.FirebaseKorisnik.KljucFirebase = response.Key;

                return true;
            }
            catch (Exception e)
            {
                Debug.Write(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
                return false;
            }
        }

        /// <summary>
        /// Obrisi korisnicku aktivnost s firebesja
        /// </summary>
        /// <returns></returns>
        public async Task ObrisiAktinostNaFireBejsu()
        {
            try
            {
                await client
                 .Child(new StringBuilder(StatickeVarijable.FIREBASE_MAIN_NODE)
                 .Append("/" + TrenutniKorisnik.FirebaseKorisnik.KljucFirebase).ToString())
                 .DeleteAsync();

                TrenutniKorisnik.FirebaseKorisnik = null;
            }
            catch (Exception e)
            {
                Debug.Print(new StringBuilder(StatickeVarijable.ERROR).Append(e.Message).ToString());
            }
        }
    }
}
