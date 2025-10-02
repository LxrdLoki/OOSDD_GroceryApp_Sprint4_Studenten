# GroceryApp sprint4 Studentversie  

## UC10 Productaantal in boodschappenlijst
Aanpassingen zijn compleet.

## UC11 Meest verkochte producten
Vereist aanvulling:  
- Werk in GroceryListItemsService de methode GetBestSellingProducts uit.  
- In BestSellingProductsView de kop van de tabel aanvullen met de gewenste kopregel boven de tabel. Daarnaast de inhoud van de tabel uitwerken.

## UC13 Klanten tonen per product  
Deze UC toont de klanten die een bepaald product hebben gekocht:  
- Maak enum Role met als waarden None en Admin.  
- Geef de Client class een property Role metb als type de enum Role. De default waarde is None.  
- In Client Repo koppel je de rol Role.Admin aan user3 (= admin).
- In BoughtProductsService werk je de Get(productid) functie uit zodat alle Clients die product met productid hebben gekocht met client, boodschappenlijst en product in de lijst staan die wordt geretourneerd.  
- In BoughtProductsView moet de naam van de Client ewn de naam van de Boodschappenlijst worden getoond in de CollectionView.  
- In BoughtProductsViewModel de OnSelectedProductChanged uitwerken zodat bij een ander product de lijst correct wordt gevuld.  
- In GroceryListViewModel maak je de methode ShowBoughtProducts(). Als de Client de rol admin heeft dan navigeer je naar BoughtProductsView. Anders doe je niets.  
- In GroceryListView voeg je een ToolbarItem toe met als binding Client.Name en als Command ShowBoughtProducts.  

## GitFlow beschrijving

Main: bevat alleen geteste, productieklaar code. Merges naar main gebeuren na validatie. 

Dev: integratiebranch voor features en bugfixes, waar pipelines draaien voor tests en builds.

Feature: voor het ontwikkelen van nieuwe functionaliteiten, wordt gemerged naar dev

Bugfix: voor het oplossen van eventuele bugs

Meer informatie -> https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow

## Workflow

* Maak een nieuwe branch gebaseerd op dev (git checkout -b feature/UC1 dev)

* Ontwikkel, commit met conventionele berichten, push regelmatig

* Maak een pull request naar dev en review

* Na merge draaien pipelines automatisch

* Als dev stabiel is: merge dev naar main via pull request

* Tag de release (bv. v0.0.1)

Meer informatie -> https://git-scm.com/book/en/v2/Git-Basics-Tagging
