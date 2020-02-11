# Hurtownia chemiczna 
## B2B - hurtownia jako firma i klient jest firma

1. Firma mo�e zarejestrowa� si� z poziomu logowania, a nast�pnie zalogowa� si� danymi utworzonego konta
2. Dodawanie, edycja, usuwanie produkt�w hurtowni (nazwa, cena)
3. Tworzenie, edycja zam�wie� przez klient�w
4. Realizacja zam�wie� przez hurtowni� (pracownik hurtowni usuwa zam�wienie)

Dane logowania:
Pracownik: login i has�o: p
Firma: login i has�o: f lub f2 lub f3

## Opis dzia�ania

1. Logowanie
- Okno umo�liwia rejestracj� nowej firmy
- Dane do logowania nale�y wpisac z konta zarejestrowanej firmy
- Zamkni�cie okno logowania lub klikni�cie w nim przycisku Zamknij, zamknie r�wnie� ca�� aplikacj�
- W systemie dost�pna jest opcja Wylogowania za pomoc� przycisku Wyloguj po prawej stronie

2. Okno listy zam�wie� (u�ytkownik)
- U�ytkownikowi wy�wietlaj� si� jego w�a�ne zam�wienia
- Edycja zam�wienia otwiera sie po dwukrotnym klikni�ciu na dany rekord zam�wienia

3. Okno listy zam�wie� (pracownik)
- Pracownikowi wy�wietlaj� si� wszystkie zam�wienia z systemu
- Pracownik mo�e edytowa� zam�wienia jak zwyk�y u�ytkownik

4. Okno edycji zam�wienia (lub przycisk Dodaj zam�wienie)
- Zam�wienie musi mie� podany tytu�.
- Ni�ej wy�wietlana jest lista produkt�w zam�wienia
- Przycisk Lista produkt�w pozwala na dodawanie produkt�w do edytowanego zam�wienia
- Dodanie produktu odbywa si� przez dwukrotne klikni�cie na Li�cie produkt�w, je�eli okno Listy produkt�w zosta�o otwarte z poziomu edycji zam�wienia

5. Lista produkt�w
- Lista produkt�w umo�liwia wy�wietlenie i edycj� wszystkich produkt�w w systemie
- Edycja produktu odbywa si� przez dwukrotne klikni�cie produktu na li�cie
- Przycisk Dodaj produkt umo�liwia dodanie nowego produktu

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
