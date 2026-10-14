# StorageApp

Ez egy .NET MAUI-val készült kis mobilalkalmazás. Egy üzlet készletkezelő rendszerét szimulálja: lehetővé teszi termékek létrehozását és megtekintését egy helyi SQLite-adatbázisból.

## Q&A
1. Milyen technikai döntéseket hoztál?

    - Korábban már terveztem hasonló alkalmazást így az ott használt UI felépítést használtam. Az adattároláshoz a sqlite-net-pcl NuGet packaget választottam mert ez lehetővé tette az SQLite-adatbázis egyszerű kezelését az alkalmazáson belül. Az alkalmazást a saját telefonomon teszteltem.

2. Volt-e olyan megoldás vagy részfeladat, amelyet több idő rendelkezésre állása esetén másképp valósítanál meg?

    - Szerintem a UI megvalósításán lehetne finomítani, hogy szebben nézzen ki. A törléshez funkció bővítéséhez egy ikont raknék a főoldalra, hogy onnan is lehessen terméket törölni.

3. Milyen további fejlesztéseket tennél bele?

    - A termékek rendelkeznek vonalkóddal ezért azokat ábrázolnám, mivel a vonalkódok beazonosítják a terméket ezért esetleg egy külső adatbázissal össze lehetne kötni az appot hogy a termékadatokat automatikusan vonalkódbeolvasássaé fel lehessen vinni.
    - A lokális adattárolás lecserélném egy központi szerverre amivel az alkalmazás egy API-n keresztül kommunikálna.

