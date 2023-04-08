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

        wordsList.Add(new Word("KATT", "A soft and furry animal often kept as a pet.", "NO", 1));
        wordsList.Add(new Word("BOKS", "A container used to store items or food.", "NO", 1));
        wordsList.Add(new Word("BIEN", "A flying insect that makes honey.", "NO", 1));
        wordsList.Add(new Word("KANIN", "A soft and fluffy hare often kept as a pet.", "NO", 1));
        wordsList.Add(new Word("KAKE", "A sweet pastry usually served for dessert.", "NO", 1));
        wordsList.Add(new Word("FUGL", "A warm-blooded, egg-laying vertebrate that has feathers.", "NO", 2));
        wordsList.Add(new Word("SKOG", "A place with many trees and other plants.", "NO", 2));
        wordsList.Add(new Word("BILDE", "A visual representation of something or someone.", "NO", 1));
        wordsList.Add(new Word("TREHUS", "A building made of wood that is used as a residence.", "NO", 1));
        wordsList.Add(new Word("ELG", "A large herbivorous deer with large antlers.", "NO", 1));
        wordsList.Add(new Word("SYKKEL", "A two-wheeled vehicle powered by pedals.", "NO", 1));
        wordsList.Add(new Word("BÆR", "A small fruit that is usually red or blue.", "NO", 1));
        wordsList.Add(new Word("VINDU", "An opening in the wall of a building for light and air.", "NO", 1));
        wordsList.Add(new Word("GRØNNSAK", "An edible plant or part of a plant that is not a fruit or grain.", "NO", 2));
        wordsList.Add(new Word("KOPP", "A container used for drinking liquids.", "NO", 1));
        wordsList.Add(new Word("SJØ", "A large body of saltwater.", "NO", 2));
        wordsList.Add(new Word("MAT", "Any substance that is eaten for nourishment.", "NO", 1));
        wordsList.Add(new Word("KAMERA", "A device used for taking photographs or videos.", "NO", 2));
        wordsList.Add(new Word("SOL", "A star that provides light and warmth.", "NO", 1));
        wordsList.Add(new Word("STOL", "A piece of furniture used for sitting on.", "NO", 1));
        wordsList.Add(new Word("TV", "An electronic device used for displaying images and sound.", "NO", 1));
        wordsList.Add(new Word("FJELL", "A large natural elevation on the earth's surface.", "NO", 2));
        wordsList.Add(new Word("MUSIKK", "An art form that uses sound and rhythm.", "NO", 2));

        wordsList.Add(new Word("HAUS", "German word for 'house'.", "DE", 1));
        wordsList.Add(new Word("BROT", "German word for 'bread'.", "DE", 1));
        wordsList.Add(new Word("BAUM", "German word for 'tree'.", "DE", 1));

        wordsList.Add(new Word("VOITURE", "French word for 'car'.", "FR", 1));
        wordsList.Add(new Word("LIVRE", "French word for 'book'.", "FR", 1));
        wordsList.Add(new Word("CHAT", "French word for 'cat'.", "FR", 1));

        wordsList.Add(new Word("CASA", "Spanish word for 'house'.", "ES", 1));
        wordsList.Add(new Word("LIBRO", "Spanish word for 'book'.", "ES", 1));
        wordsList.Add(new Word("GATO", "Spanish word for 'cat'.", "ES", 1));

        //wordsList.Add(new Word("家族", "Japanese word for 'family'.", "JA", 1));
        //wordsList.Add(new Word("太陽", "Japanese word for 'sun'.", "JA", 1));
        //wordsList.Add(new Word("寿司", "Japanese word for 'sushi'.", "JA", 1));

        wordsList.Add(new Word("บ้าน", "Thai word for 'house'.", "TH", 1));
        wordsList.Add(new Word("ข้าว", "Thai word for 'rice'.", "TH", 1));
        wordsList.Add(new Word("ช้าง", "Thai word for 'elephant'.", "TH", 1));


        return wordsList;
    }
}
