OOP principu lietojums:
---Mantošana:
-Character klase: Bāzes klase gan player, gan enemies. Character klase satur kopīgās īpašības un metodes health, weapon un damage.
-Player un Enemy klases: Abas klases manto no Character klases.
-Weapon un atvasinātās klases: Weapon klase ir abstrakta un tai ir divas atvasinātās klases: BasicWeapon un PoisonWeapon. Abstraktā Weapon klase nosaka pamata ieroču uzvedību (damage aprēķināšana un efektu pielietošana).


---Enkapsulācija:
-Īpašības un piekļuves kontrole: Spēlētāja hp, ierocis un vairogs ir enkapsulēti, izmantojot īpašības un privātas mainīgās vērtības.
-Weapon un Shield klasēs ir getter metodes, kas nodrošina, ka šie lauki nevar tikt tieši piekļauti vai modificēti no citām klasēm.
-Vairoga bloķēšanas mehānisms: Vairoga statuss (active/inactive) un atlikušās lietošanas reizes tiek glabātas privāti, un metodes ToggleShield un BlockDamage kontrolē tā darbību.


--Polimorfisms:
-Overload tiek izmantots Weapon klasē ar GetDamage() metodi, kas var aprēķināt damage atkarībā no dažādiem ieročiem.
-Override parādās Attack metodē gan Player, gan Enemy klasēs. Player klase izmanto savu ieroci, lai uzbruktu, bet Enemy klasei ir pielāgota damage aprēķināšanas loģika.


--Abstrakcija:
-Abstrakta Weapon klase: Weapon klase ir abstrakta un nosaka kopīgas funkcijas ar metodēm, piemēram, GetDamage().
-Metode ApplyEffect() tiek pielietota atvasinātajās klasēs, piemēram, PoisonWeapon un BasicWeapon.

--Ko es pievienoju:

-Game over screen un restart pogu (citu neko tikmēr nevar spiest). Kad uzspiež “restart” pogu, spēle sākas no jauna.
-3 dažādi pretinieki ar atšķirīgiem uzbrukumiem: Mushroom, Berserker, Spear Goblin
-Shield: Shield var bloķēt noteiktu daudzumu bojājumu, taču pēc 5 lietošanas reizēm tas saplīst. Tā statuss (active/inactive) tiek parādīts UI.
-Audio: Skaņas priekš attack, shield active/inactive stadijām, shield break
