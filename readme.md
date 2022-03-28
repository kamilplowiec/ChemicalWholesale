# Hurtownia chemiczna 
## B2B - hurtownia - sklep

![Hurtownia chemiczna](https://kamilplowiec.tk/img/portfolio/csdesktop2.jpg)

1. Firma może zarejestrować się z poziomu logowania, a następnie zalogować się danymi utworzonego konta
2. Dodawanie, edycja, usuwanie produktów hurtowni (nazwa, cena)
3. Tworzenie, edycja zamówień przez klientów
4. Realizacja zamówień przez hurtownię (pracownik hurtowni usuwa zamówienie)

Dane logowania:
- Pracownik - login i hasło: p
- Firma - login i hasło: f lub f2 lub f3

## Opis działania

1. Logowanie
- Okno umożliwia rejestrację nowej firmy
- Dane do logowania należy wpisac z konta zarejestrowanej firmy
- Zamknięcie okno logowania lub kliknięcie w nim przycisku Zamknij, zamknie również całą aplikację
- W systemie dostępna jest opcja Wylogowania za pomocą przycisku Wyloguj po prawej stronie

2. Okno listy zamówień (użytkownik)
- Użytkownikowi wyświetlają się jego właśne zamówienia
- Edycja zamówienia otwiera sie po dwukrotnym kliknięciu na dany rekord zamówienia

3. Okno listy zamówień (pracownik)
- Pracownikowi wyświetlają się wszystkie zamówienia z systemu
- Pracownik może edytować zamówienia jak zwykły użytkownik

4. Okno edycji zamówienia (lub przycisk Dodaj zamówienie)
- Zamówienie musi mieć podany tytuł.
- Niżej wyświetlana jest lista produktów zamówienia
- Przycisk Lista produktów pozwala na dodawanie produktów do edytowanego zamówienia
- Dodanie produktu odbywa się przez dwukrotne kliknięcie na Liście produktów, jeżeli okno Listy produktów zostało otwarte z poziomu edycji zamówienia

5. Lista produktów
- Lista produktów umożliwia wyświetlenie i edycję wszystkich produktów w systemie
- Edycja produktu odbywa się przez dwukrotne kliknięcie produktu na liście
- Przycisk Dodaj produkt umożliwia dodanie nowego produktu

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
