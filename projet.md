# Projet Architecture logiciel

Vous pouvez partir du code fait en cours ou non.

# I- Sujet

## Application 

L'application devra être une API web en micro services. Elle devra utiliser une bibliothèque que vous allez créer afin d'automatiser les standards d'une API REST.

## La base

Votre librairie devra impléter par défaut un CRUD (Create, Read, Update, Delete), un tri, une pagination et une réponse partiel.
Lors du développement de l'API à partir de votre librairie, le développeur devra créer un minimum de fichier et de ligne de code pour implémenter le CRUD.
Les différents modules peuvent être utilisés ensemble lors d'un même appel.

## Version

Les APIs devront être versionnée pour chaque controleur et/oum éthode.
Vous devez mettre en place le versionning d'API comme ceci: https://xxxxx.com/catalog/v1/ 

[aide](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Versioning/)


## Pagination

Vous allez implémenter la pagination en utilisant le paramètre de requête ?range=0-25 et les Header standards HTTP pour la réponse:  Content-Range & Accept-Range.
Voici comment les links doivent être présent dans le header de retour:
Link: <https://xxxxx.com/catalog/v1/products/orders?range=0-7>; rel="first", <https://xxxxx.com/catalog/v1/products/orders?range=40-47>; rel="prev",  <https://xxxxx.com/catalog/v1/products/orders?range=56-64>; rel="next", <https://api.xxxxx.com/catalog/v1/products/orders?range=968-975>; rel="last"

Voici ce que contient également le header dans le cas d'une pagination:
Content-Range: 0-47/48
Accept-Range: product 50

## Tris

Le tri du résultat d’un appel sur une collection de ressources passe par deux principaux paramètres :

sort : contient les noms des attributs, séparés par une virgule, sur lesquels effectuer le trie.
desc : par défaut le tri est ascendant (ou croissant), afin de l’obtenir de façon descendant (ou décroissant), il suffit d’ajouter ce paramètre (sans valeur par défaut). On voudra dans certains cas spécifier que les attributs doivent être traités de façon ascendant ou descendant, on mettra alors dans ce paramètre la liste des attributs descendants, les autres seront donc par défaut ascendants.

Vous devrez inclure un tri sous la forme suivante: https://xxxxx.com/catalog/v1/products?asc=rating&desc=name

## Filtres
Vous devrez inclure dans votre librairie un filtre générique sous la forme suivante: http://xxxxx.com/catalog/v1/products?type=pizza,pates&rating=4,5&days=sunday
Sur une chaine de caratères:
- l'utilisateur peut rechercher une valeur fixe (type=pizza) 
- l'utilisateur peut rechercher plusieurs valeurs,  ex les produits de type 'pizza' ou 'pates' (type=pizza,pate)

Sur les valeurs numériques:
- l'utilisateur peut rechercher une valeur fixe (rating=4) 
- l'utilisateur peut rechercher plusieurs valeurs,  ex les produits de rating '4' ou '5' (rating=4,5)
- l'utilisateur peut rechercher des fourchettes de valeurs,  ex les produits de rating compris en '4' et '10' (rating=[4,10])
- l'utilisateur peut rechercher des valeurs inférieurs ou égal,  ex les produits de rating inférieur ou egal à '10' (rating=[,10])
- l'utilisateur peut rechercher des valeurs supérieurs ou égal,  ex les produits de rating séperieur ou égal à '4' (rating=[4,])

Sur les valaurs de temps:
- l'utilisateur peut rechercher une valeur fixe (createdat=04-04-2020)
- l'utilisateur peut rechercher plusieurs valeurs,  ex les produits créés le 04/04/2020 ou le 05/05/2020 (createdat=04-04-2020,05-05-2020)
- l'utilisateur peut rechercher des fourchettes de valeurs,  ex les produits créés entre le 04/04/2020 et le 05/05/2020 (createdat=[04-04-2020,05-05-2020])
- l'utilisateur peut rechercher des valeurs inférieurs ou égal,  ex les produits créés avant le 05/05/2020 (createdat=[,05-05-2020])
- l'utilisateur peut rechercher des valeurs supérieurs ou égal,  ex les produits créés après le 04/04/2020 (createdat=[04-04-2020,])

## Recherche

Vous devrez inclure dans votre librairie une recherche générique sous la forme suivante: http://xxxxx/catalog/v1/products/search?name=*napoli*&type=pizza,pate&sort=rating,name

## Réponses partielles
Les réponses partielles permettent au client de récupérer uniquement les informations dont il a besoin. Cette fonctionnalité est par ailleurs primordiale pour les contextes en utilisation nomade (3G-), ou la bande passante doit être optimisée.
Vous devez inclure un système de réponse partielle sous la forme suivante: http://xxxxx/catalog/v1/products&fields=id,name
Les objets retournés seront constitués QUE de l'ID et du NAME.

## Logs

Vous devez impléter les logs dans votre librairie avec le système SeriLog [aide](https://github.com/serilog/serilog-aspnetcore)
Chaque appel de controlleur doit être loguer.

## Tests unitaires

Un projet de test unitaire devra être réalisé pour la librairie.
Un projet de test unitaire devra être réalisé pour l'API de dev.

## Base de données

Vous êtes obligé d'utiliser un ORM: EntityFramework.
Vous pouvez (fortement conseillé) utiliser les migrations.

## Web API

Vous devrez réaliser la doc de l'API avec SwaggerUI [aide](https://swagger.io/swagger-ui/)

[aide 2](https://docs.microsoft.com/fr-fr/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio)

## Authentification (bonus: 3 points)

Vous devez implétementer une authentification OAuth2/OpenID dans votre librairie via un token JWT afin que le dévellopeur choisisse ou non de l'activer sur l'API.


## CI/CD (bonus: 3 points)

Vous pouvez implétementer un système DevOps de votre choix (Azuredevops, Gitlab, Jenkins, ...) afin de créer une intégration continue.
Vous devez intégrer les tests unitaires dans l'intégration continue.
L'intégration continue devra gérer le process complet du Git au déploiement docker.


# Groupes et fonctionnement

Le projet est a développé en groupe de 4 personnes.
Tous les groupes seront définis en cours, sous la supervision de l'enseignant. Les groupes s'enregistrent avec un nom de groupe ainsi que les noms de leurs membres.

Toute inscription est définitive.  Les étudiants ne sont pas autorisés, par la suite, à changer de groupe.

Au sein d'un groupe, les étudiants se répartiront les tâches pour le projet, de façon équitable.  Il est explicitement exigé que chaque membre consacre au moins 50% de son travail à du développement technique. Du code de test est acceptable, tant qu'il ne constitue pas l'intégralité de la réalisation technique du membre du groupe.

Les étudiants sont encouragés (mais pas obligés) à mettre en place un système de contrôle des sources de type Git ou équivalent, afin d'affecter et partager efficacement les fichiers de codes et autres composants numériques du projet (fichiers sources, descripteurs de déploiement, documents de recherche, cas d'utilisation, suites de tests, etc.).

# Soutenance et rendu

La soutenance aura lieux le jeudi 17 novembre 2022.
Les horaires de passage sont définis pour chaque groupe.
Toute absence à la soutenance entrainera un 0 (ZERO) pour le membre du groupe.

Les rendus doivent figurer sur un seul compte par groupe.
Le rendu s'effectu via un repos GIT ou SVN. L'adresse du rendu est envoyé par mail.
Le mail de rendu est vincent.leclerc@ynov.com
Les fichiers rendus doivent contenir
  - L'arborescence du projet, immédiatement exploitable après création des bases de données et exécution des migrations.
  - Un AUTHORS.TXT listant les membres du groupe (prénom, nom), à raison d'un par ligne.  Il liste ensuite les responsabilités effectives de chacun dans le groupe.
Le sujet du mail doit contenir votre section ainsi que le nom du projet.
Les fichiers rendus peuvent aussi comprendre: 
  - Des documents de recherche créés pour le projet et fournissant plus de détails pour l'enseignant.
Pour tout autre type de fichier, veuillez demander à l'enseignant si son inclusion est appropriée.
La soutenance dure 20 minutes durant lesquelles les membres présentent leur travail. Un échange de questions peut se faire entre le professeur et les membres du groupe.

Les groupes sont les suivants:
- Clément WALSH DE SERRANT / Clément DUFOUR LAMARTINIE / Faouizi MZEBLA / Marvin GOMES VITORINO
- LECORNET Killian / CRESPO Matthias / MAGNANT Léo / SEVAULT Lucas
- BOURAS Nadia / BEN FRAJ Fairouz / ARHAB Koceila / OUERDANE Yanis
- CISSE Djibril / JANKOWSKI Thomas / LARABI Abdelghani / MARCHAO Hugo
- GEORGES Elodie / AMRAOUI Zakaria / GAPASIN Marc / SEMERDJIAN Haig
- EGRO Kejsi / LEHNA Ryme / SORIANO Precious / DANG Ngoc Ha Lan
- AYACHE Salim / KUETE JIOTSA Charlot Junior / MBABOU Romario Ulrich
- JAAFAR Amir / MASSÉ Jérémy / OLIVRIE Aubin / PEYROT Ryan
- PELENIO Dj Everson / DHOUIB Mohamed Ali / MANGANO Luka / KOMGUEM Lionel
- CHEONG David / MEGBLETO Carnel / BELMADKOUR Oumaima / SABBATORSI Enzo

Les horaires de passage des groupes sont les suivants:
- 10h15 => Clément WALSH DE SERRANT / Clément DUFOUR LAMARTINIE / Faouizi MZEBLA / Marvin GOMES VITORINO
- 10h45 => EGRO Kejsi / LEHNA Ryme / SORIANO Precious / DANG Ngoc Ha Lan
- 11h15 => LECORNET Killian / CRESPO Matthias / MAGNANT Léo / SEVAULT Lucas
- 11h45 => GEORGES Elodie / AMRAOUI Zakaria / GAPASIN Marc / SEMERDJIAN Haig
- 12h15 => PELENIO Dj Everson / DHOUIB Mohamed Ali / MANGANO Luka / KOMGUEM Lionel
- 12h45 => CISSE Djibril / JANKOWSKI Thomas / LARABI Abdelghani / MARCHAO Hugo
- 14h15 => BOURAS Nadia / BEN FRAJ Fairouz / ARHAB Koceila / OUERDANE Yanis
- 14h45 => JAAFAR Amir / MASSÉ Jérémy / OLIVRIE Aubin / PEYROT Ryan
- 15h15 => AYACHE Salim / KUETE JIOTSA Charlot Junior / MBABOU Romario Ulrich
- 15h45 => CHEONG David / MEGBLETO Carnel / BELMADKOUR Oumaima / SABBATORSI Enzo


Pour ceux dont le groupe n'est pas dans la liste, contactez-moi très rapidement à vincent.leclerc@ynov.com