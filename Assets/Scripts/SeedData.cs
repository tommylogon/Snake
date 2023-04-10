using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameAssets;

public static class SeedData 
{
    public static List<Word> wordsList = new List<Word>(); 
    public static List<Word> InitialWords()
    {
        wordsList.Clear();
        wordsList.Add(new Word("BEAR", "A furry animal that hibernates in the winter.", Language.English, 1));
        wordsList.Add(new Word("APPLE", "A small fruit that is usually red or green.", Language.English, 1));
        wordsList.Add(new Word("BEE", "A flying insect that makes honey.", Language.English, 1));
        wordsList.Add(new Word("PARROT", "A type of bird that is often kept as a pet.", Language.English, 1));
        wordsList.Add(new Word("ROSE", "A type of flower that is often associated with love.", Language.English, 1));
        wordsList.Add(new Word("CAR", "A vehicle used for transportation.", Language.English, 1));
        wordsList.Add(new Word("DOG", "A domesticated mammal often kept as a pet.", Language.English, 1));
        wordsList.Add(new Word("OCEAN", "A large body of saltwater.", Language.English, 2));
        wordsList.Add(new Word("PHONE", "A device used for communication.", Language.English, 1));
        wordsList.Add(new Word("HOUSE", "A building used for shelter.", Language.English, 1));
        wordsList.Add(new Word("ELEPHANT", "A large mammal with a trunk and tusks.", Language.English, 1));
        wordsList.Add(new Word("GUITAR", "A musical instrument with strings.", Language.English, 1));
        wordsList.Add(new Word("WATER", "A clear liquid essential for life.", Language.English, 1));
        wordsList.Add(new Word("BOOK", "A written or printed work.", Language.English, 2));
        wordsList.Add(new Word("LION", "A large carnivorous mammal.", Language.English, 1));
        wordsList.Add(new Word("PIZZA", "A dish made of dough, sauce, and toppings.", Language.English, 2));
        wordsList.Add(new Word("SUN", "A star that provides light and heat.", Language.English, 1));
        wordsList.Add(new Word("CHAIR", "A piece of furniture used for sitting.", Language.English, 1));
        wordsList.Add(new Word("TREE", "A perennial plant with a single stem or trunk.", Language.English, 3));
        wordsList.Add(new Word("MOUNTAIN", "A large natural elevation of the earth's surface.", Language.English, 2));
        wordsList.Add(new Word("MUSIC", "An art form that uses sound and rhythm.", Language.English, 2));
        wordsList.Add(new Word("HORSE", "A large four-legged mammal used for riding.", Language.English, 1));
        wordsList.Add(new Word("KEYBOARD", "A device used for typing on a computer.", Language.English, 2));
        wordsList.Add(new Word("MIRROR", "A reflective surface used for viewing oneself.", Language.English, 1));
        wordsList.Add(new Word("PENCIL", "A writing tool used to make marks on paper.", Language.English, 1));
        wordsList.Add(new Word("BIRD", "A warm-blooded egg-laying vertebrate.", Language.English, 2));
        wordsList.Add(new Word("CLOUD", "A visible mass of condensed water vapor floating in the atmosphere.", Language.English, 2));
        wordsList.Add(new Word("COMPUTER", "An electronic device used for storing and processing data.", Language.English, 2));
        wordsList.Add(new Word("CUP", "A small, open container used for holding liquids.", Language.English, 1));
        wordsList.Add(new Word("FISH", "A cold-blooded aquatic vertebrate.", Language.English, 1));
        wordsList.Add(new Word("FLOWER", "A plant part that is usually brightly colored.", Language.English, 1));
        wordsList.Add(new Word("FOOTBALL", "A game played with a ball and two teams.", Language.English, 1));

        wordsList.Add(new Word("KATT", "A soft and furry animal often kept as a pet.", Language.Norwegian, 1));
        wordsList.Add(new Word("BOKS", "A container used to store items or food.", Language.Norwegian, 1));
        wordsList.Add(new Word("BIEN", "A flying insect that makes honey.", Language.Norwegian, 1));
        wordsList.Add(new Word("KANIN", "A soft and fluffy hare often kept as a pet.", Language.Norwegian, 1));
        wordsList.Add(new Word("KAKE", "A sweet pastry usually served for dessert.", Language.Norwegian, 1));
        wordsList.Add(new Word("FUGL", "A warm-blooded, egg-laying vertebrate that has feathers.", Language.Norwegian, 2));
        wordsList.Add(new Word("SKOG", "A place with many trees and other plants.", Language.Norwegian, 2));
        wordsList.Add(new Word("BILDE", "A visual representation of something or someone.", Language.Norwegian, 1));
        wordsList.Add(new Word("TREHUS", "A building made of wood that is used as a residence.", Language.Norwegian, 1));
        wordsList.Add(new Word("ELG", "A large herbivorous deer with large antlers.", Language.Norwegian, 1));
        wordsList.Add(new Word("SYKKEL", "A two-wheeled vehicle powered by pedals.", Language.Norwegian, 1));
        wordsList.Add(new Word("BÆR", "A small fruit that is usually red or blue.", Language.Norwegian, 1));
        wordsList.Add(new Word("VINDU", "An opening in the wall of a building for light and air.", Language.Norwegian, 1));
        wordsList.Add(new Word("GRØNNSAK", "An edible plant or part of a plant that is not a fruit or grain.", Language.Norwegian, 2));
        wordsList.Add(new Word("KOPP", "A container used for drinking liquids.", Language.Norwegian, 1));
        wordsList.Add(new Word("SJØ", "A large body of saltwater.", Language.Norwegian, 2));
        wordsList.Add(new Word("MAT", "Any substance that is eaten for nourishment.", Language.Norwegian, 1));
        wordsList.Add(new Word("KAMERA", "A device used for taking photographs or videos.", Language.Norwegian, 2));
        wordsList.Add(new Word("SOL", "A star that provides light and warmth.", Language.Norwegian, 1));
        wordsList.Add(new Word("STOL", "A piece of furniture used for sitting on.", Language.Norwegian, 1));
        wordsList.Add(new Word("TV", "An electronic device used for displaying images and sound.", Language.Norwegian, 1));
        wordsList.Add(new Word("FJELL", "A large natural elevation on the earth's surface.", Language.Norwegian, 2));
        wordsList.Add(new Word("MUSIKK", "An art form that uses sound and rhythm.", Language.Norwegian, 2));

        wordsList.Add(new Word("HAUS", "German word for 'house'.", Language.German, 1));
        wordsList.Add(new Word("BROT", "German word for 'bread'.", Language.German, 1));
        wordsList.Add(new Word("BAUM", "German word for 'tree'.", Language.German, 1));

        wordsList.Add(new Word("VOITURE", "French word for 'car'.", Language.French, 1));
        wordsList.Add(new Word("LIVRE", "French word for 'book'.", Language.French, 1));
        wordsList.Add(new Word("CHAT", "French word for 'cat'.", Language.French, 1));

        wordsList.Add(new Word("CASA", "Spanish word for 'house'.",Language.Spannish, 1));
        wordsList.Add(new Word("LIBRO", "Spanish word for 'book'.", Language.Spannish, 1));
        wordsList.Add(new Word("GATO", "Spanish word for 'cat'.", Language.Spannish, 1));

        wordsList.Add(new Word("KAZOKU", "Japanese word for 'family'.", Language.Japanese, 1));
        wordsList.Add(new Word("TAIYOU", "Japanese word for 'sun'.", Language.Japanese, 1));
        wordsList.Add(new Word("SUSHI", "Japanese word for 'sushi'.", Language.Japanese, 1));

        wordsList.Add(new Word("BAAN", "Thai word for 'house'.", Language.Thai, 1));
        wordsList.Add(new Word("KHAAO", "Thai word for 'rice'.", Language.Thai, 1));
        wordsList.Add(new Word("CHAANG", " Thai word for 'elephant'.", Language.Thai, 1));


        return wordsList;
    }
}
