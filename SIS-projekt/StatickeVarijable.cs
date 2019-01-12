using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_projekt
{
    public class StatickeVarijable
    {
        //ERROR
        public const String ERROR = "ERROR: ";

        //DATOTEKE
        public const String KORISNICKIPODACI = "korisnickipodaci.json";
        public const String DATOTEKA_KLJUC_AES = "kljuc_AES.txt"; //AES
        public const String DATOTEKA_JAVNI_KLJUC = "javniK_RSA.txt"; //RSA
        public const String DATOTEKA_PRIVATNI_KLJUC = "privatniK_RSA.txt"; //RSA

        //AES Vektor
        public const int AES_LENGTH_BYTE = 16;

        //FIREBASE
        public const String FIREBASE_MAIN_NODE = "users";
        public const String FIREBASE_PATH = @"https://sisprojekt-bd73e.firebaseio.com/";
        public const String FIREBASE_AUTH = "j4wxjTRH4JMohMN4lJVtIbKDfw0m6LdzY9GcaFnr";

        //KRIPTIRANJE -> bitovi
        public const int VELICINA_KLJUCA_RSA = 2048;
        public const int SAZETAK_SHA256 = 256;
        public const int POSILJATELJ = 160;

        //SOCKETI
        public const String PORUKA_PRIMLJENA = "PRIMLJENO";
        public const String LOCALHOST = "127.0.0.1";
        public const int BROJ_PRIMATELJA = 5;
    }
}
