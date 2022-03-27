# Hurtownia chemiczna 
## B2B - hurtownia jako firma i klient jest firma

![Hurtownia chemiczna](https://kamilplowiec.tk/img/portfolio/csdesktop2.jpg)

1. Firma mo¿e zarejestrowaæ siê z poziomu logowania, a nastêpnie zalogowaæ siê danymi utworzonego konta
2. Dodawanie, edycja, usuwanie produktów hurtowni (nazwa, cena)
3. Tworzenie, edycja zamówieñ przez klientów
4. Realizacja zamówieñ przez hurtowniê (pracownik hurtowni usuwa zamówienie)

Dane logowania:
Pracownik: login i has³o: p
Firma: login i has³o: f lub f2 lub f3

## Opis dzia³ania

1. Logowanie
- Okno umo¿liwia rejestracjê nowej firmy
- Dane do logowania nale¿y wpisac z konta zarejestrowanej firmy
- Zamkniêcie okno logowania lub klikniêcie w nim przycisku Zamknij, zamknie równie¿ ca³¹ aplikacjê
- W systemie dostêpna jest opcja Wylogowania za pomoc¹ przycisku Wyloguj po prawej stronie

2. Okno listy zamówieñ (u¿ytkownik)
- U¿ytkownikowi wyœwietlaj¹ siê jego w³aœne zamówienia
- Edycja zamówienia otwiera sie po dwukrotnym klikniêciu na dany rekord zamówienia

3. Okno listy zamówieñ (pracownik)
- Pracownikowi wyœwietlaj¹ siê wszystkie zamówienia z systemu
- Pracownik mo¿e edytowaæ zamówienia jak zwyk³y u¿ytkownik

4. Okno edycji zamówienia (lub przycisk Dodaj zamówienie)
- Zamówienie musi mieæ podany tytu³.
- Ni¿ej wyœwietlana jest lista produktów zamówienia
- Przycisk Lista produktów pozwala na dodawanie produktów do edytowanego zamówienia
- Dodanie produktu odbywa siê przez dwukrotne klikniêcie na Liœcie produktów, je¿eli okno Listy produktów zosta³o otwarte z poziomu edycji zamówienia

5. Lista produktów
- Lista produktów umo¿liwia wyœwietlenie i edycjê wszystkich produktów w systemie
- Edycja produktu odbywa siê przez dwukrotne klikniêcie produktu na liœcie
- Przycisk Dodaj produkt umo¿liwia dodanie nowego produktu

6. Okno edycji produktu
- Produkt zawiera dane takie, jak Nazwa i Cena

## Tabele
1. Klient
- id
- nazwa
- adres
- nip
- login
- haslo

2. Produkt 
- id
- nazwa
- cena

3. Zamowienie
- id
- klient_id

4. ProduktZamowienia
- id
- zamowienie_id
- produkt_id
- opis
