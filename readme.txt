=======================================================
================== PRVNÍ SPUŠTĚNÍ =====================
=======================================================

1) Nainstalujte MySql server z officiálních stránek Mysql
2) otevřete soubor v Data\Config\Config.txt
3) Změňte User ID a heslo na příslušné, které jste zadávali při instalaci serveru jako root.
4) Soubor uložte
5) Hra si vytvoří vlastní databázi, tato systémová slouží pouze k připojení a vytvoření databáze a potřebných dat. Při odstranění všech dat se stačí ve hřee přihlásit za admina hned v úvodu a zvolit smazat. Tímto se smaže celá databáze, kterou si hra vytvořila
6) Nyní už spusťte hru 'Etermium.exe', která by měla v pořádku fungovat.
7) Pokud chcete smazat všechna data před "odinstalováním" hry, spusťte hru a hned v první sekci, kde zadáváte název hry zadejte 'admin' a vstoupíte do kompletní správy databáze všech uživatelů. Zde smažete všechna data a poté můžete hru smazat z disku.

- Etermium je textová hra založená na stylu rpg.
- Hráč bojuje proti příšerám, hádá hádanky, možná projde po neviditelné mapě, či si koupí za peníze vlastnosti.
- Hra končí když:
 - hráč uloží a vypne hru
 - hráč porazí závěrečného bosse hry
 - během hraní bude zabit některou z příšer (stále si má možnost načíst dřívější uloženou pozici)
- Hra je vytvořena v jazyce C# za použití sql scriptů a připojena k mysql databázi k úkládání všech hráčů a jejich pozic
- v případě nalezených chyb vložte do ISSUE zde na Githubu

=======================================================
==================== ODINSTALACE ======================
=======================================================
- Pokud chcete smazat všechna data před "odinstalováním" hry:
1) Spusťte hru
2) první sekci, kde zadáváte název hry zadejte 'admin' a vstoupíte do kompletní správy databáze všech uživatelů. 
3) Zde smažete všechna data pomocí příslušné volby a poté můžete hru smazat z disku.

=======================================================
=================== HODNĚ ŠTĚSTÍ ======================
=======================================================
