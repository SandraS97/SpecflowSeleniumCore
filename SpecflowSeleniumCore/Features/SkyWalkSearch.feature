Feature: SkyWalkSearchTEQUILA
	Provera url-a veb sajta nakon odabira stavke menija,
	kao i provera da li stranica sadrzi odredjeni tekst nakon pretrage
@SkyWalkSearchTequila
Scenario: Provera url-a nakon odabira stavke TEQUILA u meniju
	Given Otvoren je web sajt skywalk.info
	When Biram stavku TEGUILA iz stavke menija pod nazivom PRODUCTS
	Then Proveravam da li je doslo do promene url-a i da li stranica sadrzi tekst Free your mind. For the essentials.
	When Kliknem na ikonu za pretragu i ukucam rec CHILI u polju za pretragu, zatim kliknem ENTER na tastaturi i kliknem na prvi dobijeni link
	Then Proveravam da li je doslo do promene url-a, da li stranica sadrzi tekst CHILI4 – Limited Design – “Yellow”
	When Kliknem na ikonu za pretragu i ukucam rec CHILY u polju za pretragu, a zatim kliknem ENTER na tastaturi
	Then Proveravam da li je doslo do promene url-a i da li stranica sadrzi tekst NoResultsFound

