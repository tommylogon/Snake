using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SeedData 
{
    public static List<Word> wordsList = new List<Word>(); 
    public static List<Word> InitialWords()
    {
        wordsList.Add(new Word("BEAR", "A furry animal that hibernates in the winter.","EN", 1));
        wordsList.Add(new Word("APPLE", "A small fruit that is usually red or green.","EN", 1));
        wordsList.Add(new Word("BEE", "A flying insect that makes honey.", "EN", 1));
        wordsList.Add(new Word("PARROT", "A type of bird that is often kept as a pet.", "EN", 1));
        wordsList.Add(new Word("ROSE", "A type of flower that is often associated with love.", "EN", 1));
        wordsList.Add(new Word("CAR", "A vehicle used for transportation.", "EN", 1));
        wordsList.Add(new Word("DOG", "A domesticated mammal often kept as a pet.", "EN", 1));
        wordsList.Add(new Word("OCEAN", "A large body of saltwater.", "EN", 2));
        wordsList.Add(new Word("PHONE", "A device used for communication.", "EN", 1));
        wordsList.Add(new Word("HOUSE", "A building used for shelter.", "EN", 1));
        wordsList.Add(new Word("ELEPHANT", "A large mammal with a trunk and tusks.", "EN", 1));
        wordsList.Add(new Word("GUITAR", "A musical instrument with strings.", "EN", 1));
        wordsList.Add(new Word("WATER", "A clear liquid essential for life.", "EN", 1));
        wordsList.Add(new Word("BOOK", "A written or printed work.", "EN", 2));
        wordsList.Add(new Word("LION", "A large carnivorous mammal.", "EN", 1));
        wordsList.Add(new Word("PIZZA", "A dish made of dough, sauce, and toppings.", "EN", 2));
        wordsList.Add(new Word("SUN", "A star that provides light and heat.", "EN", 1));
        wordsList.Add(new Word("CHAIR", "A piece of furniture used for sitting.", "EN", 1));
        wordsList.Add(new Word("TREE", "A perennial plant with a single stem or trunk.", "EN", 3));
        wordsList.Add(new Word("MOUNTAIN", "A large natural elevation of the earth's surface.", "EN", 2));
        wordsList.Add(new Word("MUSIC", "An art form that uses sound and rhythm.", "EN", 2));
        wordsList.Add(new Word("HORSE", "A large four-legged mammal used for riding.", "EN", 1));
        wordsList.Add(new Word("KEYBOARD", "A device used for typing on a computer.", "EN", 2));
        wordsList.Add(new Word("MIRROR", "A reflective surface used for viewing oneself.", "EN", 1));
        wordsList.Add(new Word("PENCIL", "A writing tool used to make marks on paper.", "EN", 1));
        wordsList.Add(new Word("BIRD", "A warm-blooded egg-laying vertebrate.", "EN", 2));
        wordsList.Add(new Word("CLOUD", "A visible mass of condensed water vapor floating in the atmosphere.", "EN", 2));
        wordsList.Add(new Word("COMPUTER", "An electronic device used for storing and processing data.", "EN", 2));
        wordsList.Add(new Word("CUP", "A small, open container used for holding liquids.", "EN", 1));
        wordsList.Add(new Word("FISH", "A cold-blooded aquatic vertebrate.", "EN", 1));
        wordsList.Add(new Word("FLOWER", "A plant part that is usually brightly colored.", "EN", 1));
        wordsList.Add(new Word("FOOTBALL", "A game played with a ball and two teams.", "EN", 1));

        //wordsList.Add(new Word("KATT", "Et mykt og pelskledd dyr som ofte holdes som kjæledyr.", "NO", 1));
        //wordsList.Add(new Word("BOKS", "En beholder brukt til å oppbevare gjenstander eller mat.", "NO", 1));
        //wordsList.Add(new Word("BIEN", "En flygende insekt som lager honning.", "NO", 1));
        //wordsList.Add(new Word("KANIN", "En myk og lodden hare som ofte holdes som kjæledyr.", "NO", 1));
        //wordsList.Add(new Word("KAKE", "En søt bakverk som vanligvis serveres til dessert.", "NO", 1));
        //wordsList.Add(new Word("FUGL", "En varmblodig, eggleggende virveldyr som har fjær.", "NO", 2));
        //wordsList.Add(new Word("SKOG", "Et sted med mange trær og andre planter.", "NO", 2));
        //wordsList.Add(new Word("BILDE", "En visuell representasjon av noe eller noen.", "NO", 1));
        //wordsList.Add(new Word("TREHUS", "En bygning laget av tre som brukes som bolig.", "NO", 1));
        //wordsList.Add(new Word("ELG", "En stor planteetende hjort med store gevirer.", "NO", 1));
        //wordsList.Add(new Word("SYKKEL", "Et tohjulet kjøretøy som drives av pedaler.", "NO", 1));
        //wordsList.Add(new Word("BÆR", "En liten frukt som er vanligvis rød eller blå.", "NO", 1));
        //wordsList.Add(new Word("VINDU", "En åpning i veggen på en bygning for lys og luft.", "NO", 1));
        //wordsList.Add(new Word("GRØNNSAK", "En spiselig plante eller del av en plante som ikke er en frukt eller et korn.", "NO", 2));
        //wordsList.Add(new Word("KOPP", "En beholder brukt til å drikke væsker.", "NO", 1));
        //wordsList.Add(new Word("SJØ", "En stor kropp av saltvann.", "NO", 2));
        //wordsList.Add(new Word("MAT", "Enhver substans som spises for næring.", "NO", 1));
        //wordsList.Add(new Word("KAMERA", "En enhet som brukes til å ta fotografier eller video.", "NO", 2));
        //wordsList.Add(new Word("SOL", "En stjerne som gir lys og varme.", "NO", 1));
        //wordsList.Add(new Word("STOL", "Et møbel brukt til å sitte på.", "NO", 1));
        //wordsList.Add(new Word("TV", "En elektronisk enhet som brukes til å vise bilder og lyd.", "NO", 1));
        //wordsList.Add(new Word("FJELL", "En stor naturlig opphøyning på jordoverflaten.", "NO", 2));
        //wordsList.Add(new Word("MUSIKK", "En kunstform som bruker lyd og rytme.", "NO", 2));

        return wordsList;
    }
}
