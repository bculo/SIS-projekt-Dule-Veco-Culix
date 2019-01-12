# SIS-projekt-Dule-Veco-Culix
SIS projekt (Čulo, Dumančić, Grbavac)

Za implementaciju aplikacije korišten je C# (WPF)

Aplikacija služi za slanje digitalnog pečata korištenjem socketa u LAN mreži.
Svaki korisnik koji je prijavljen u aplikaciju može dohvatiti aktivne korisnike (njihov socket, javni kljuc i ime) pomoću firebase-a

Korištene biblioteke/dodaci
  JSON datoteke - https://www.newtonsoft.com/json
  Firebase - https://github.com/step-up-labs/firebase-database-dotnet
  
 Za pomoć pri implementaciji simetričnog kriptiranja korišten je primjer 
 https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=netframework-4.7.2
 
 Za pomoć pri implementaciji asimetričnog kriptiranja korišten je primjer
 https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsacryptoserviceprovider?view=netframework-4.7.2
  
