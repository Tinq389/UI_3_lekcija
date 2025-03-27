OOP principu lietojums:

Mantošana:
-Player un Enemy klases: Abas klases manto no Character klases.
-Weapon un atvasinātās klases: Weapon klase ir abstrakta un tai ir divas atvasinātās klases: BasicWeapon un PoisonWeapon.


Enkapsulācija:
-Īpašības un piekļuves kontrole: Spēlētāja hp, ierocis un vairogs ir enkapsulēti, izmantojot īpašības un privātas mainīgās vērtības.
-Weapon un Shield klasēs ir getter metodes.
-Vairoga bloķēšanas mehānisms: Vairoga statuss (active/inactive) un atlikušās lietošanas reizes tiek glabātas privāti, un metodes ToggleShield un BlockDamage kontrolē tā darbību.


Polimorfisms:
-Overload tiek izmantots Weapon klasē ar GetDamage() metodi, kas var aprēķināt damage atkarībā no dažādiem ieročiem.
-Override parādās Attack metodē gan Player, gan Enemy klasēs.


Abstrakcija:
-Abstrakta Weapon klase: Weapon klase ir abstrakta un nosaka kopīgas funkcijas ar metodēm, piemēram, GetDamage().


Ko es pievienoju:
-Game over screen un restart pogu (citu neko tikmēr nevar spiest). Kad uzspiež “restart” pogu, spēle sākas no jauna.
-3 dažādi pretinieki ar atšķirīgiem uzbrukumiem: Mushroom, Berserker, Spear Goblin
-Shield: Shield var bloķēt noteiktu daudzumu bojājumu, taču pēc 5 lietošanas reizēm tas saplīst. Tā statuss (active/inactive) tiek parādīts UI.
-Audio: Skaņas priekš attack, shield active/inactive stadijām, shield break
