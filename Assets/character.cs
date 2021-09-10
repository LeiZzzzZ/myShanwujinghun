using System.Collections.Generic;

namespace Character
{
    public class SpeedItem
    {
        public int initialIndex { get; set; }
        public List<int> array { get; set; }
    }

    public class MightItem
    {
        public int initialIndex { get; set; }
        public List<int> array { get; set; }
    }

    public class SanityItem
    {
        public int initialIndex { get; set; }
        public List<int> array { get; set; }
    }

    public class KnowledgeItem
    {
        public int initialIndex { get; set; }
        public List<int> array { get; set; }
    }

    public class CharactersItem
    {
        public string name { get; set; }
        public string age { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public List<string> hobbies { get; set; }
        public string birthday { get; set; }
        public string bio { get; set; }
        public string bio2 { get; set; }
        public List<SpeedItem> speed { get; set; }
        public List<MightItem> might { get; set; }
        public List<SanityItem> sanity { get; set; }
        public List<KnowledgeItem> knowledge { get; set; }
        public static CurrentCharacter ToCurrentCharacter(CharactersItem c)
        {
            CurrentCharacter CC = new CurrentCharacter();
            CC.name = c.name;
            CC.age = c.age;
            CC.height = c.height;
            CC.weight = c.weight;
            CC.hobbies = c.hobbies;
            CC.birthday = c.birthday;
            CC.bio = c.bio;
            CC.bio2 = c.bio2;
            CC.speed = c.speed;
            CC.might = c.might;
            CC.sanity = c.sanity;
            CC.knowledge = c.knowledge;
            CC.speedindex = c.speed[0].initialIndex;
            CC.mightindex = c.might[0].initialIndex;
            CC.sanityindex = c.sanity[0].initialIndex;
            CC.knowledgeindex = c.knowledge[0].initialIndex;
            return CC;
        }
    }

    public class CurrentCharacter : CharactersItem
    {
        public int speedindex { get; set; }
        public int mightindex { get; set; }
        public int sanityindex { get; set; }
        public int knowledgeindex { get; set; }
    }

    public class character
    {
        public List<CharactersItem> characters { get; set; }
    }
}