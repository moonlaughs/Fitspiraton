using System.Collections.ObjectModel;

namespace Fitspiraton.Model
{
    public class Activity
    {
        //auto properties
        public ObservableCollection<Activity> Activities { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string NameOfTeacher { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }

        //constructors
        public Activity(string type, double price, string nameOfTeacher, string description, string imgSource)
        {
            Type = type;
            Price = price;
            NameOfTeacher = nameOfTeacher;
            Description = description;
            ImgSource = imgSource;
        }

        public Activity()
        {
            Activities = new ObservableCollection<Activity>()
            {
                new Activity("Fitness", 100, "Bob Harper", "In two weeks you’ll feel it. In four weeks you’ll see it. In eight weeks you’ll hear it. Want to try? In Fitspiration you can find the latest available sport equipment and train every part of your body. If you are  a beginner you can start a course with one of our professional trainers! Three months from now you will thank yourself. Summer bodies are made in the winter. Start today!", "../Assets/fitness.jpg"),
                new Activity("Salsa", 110, "Ina & Zahari", "You wanna get in shape but fitness is too boring for you? You are fond of the latino rhythms? You enjoy both dancing and meeting new people? If so, Salsa is the best style of dance for you! At Fitspiration you’ll learn from world-famous Salsa instructors and meet another positive and happy salseros! Salsa LA or Cuban, lady style or rueda de casino – we have it all. Don’t hesitate and join our classes now!", "../Assets/salsa.jpg"),
                new Activity("Pole dance", 120, "Natalia Koszyk", "Pole dancing is a full-body workout. It is resistance training and cardio in one. Flexibility is improved as well. Pole dancers perform acrobatic tricks either suspending their weight or propelling it around a metal pole. The simple act of climbing a pole is an incredible display of strength. It is no surprise, then, that most pole dancers insist they have never looked or felt better.", "../Assets/pole2.jpg"),
                new Activity("Ballet", 120, "Daria Klimentová", "No matter what your dance focus, you need to know your body. The structured, methodical approach of ballet training encourages you to learn about anatomy and your own strengths and weaknesses. This wisdom will stand you in good steed for other dance styles, sports and life in general.", "../Assets/ballet3.jpg"),
                new Activity("Zumba", 100, "Steve Boe", "Ditch the Workout – Join the Party!” That’s the marketing slogan for Zumba fitness, which attracts exercisers with a fun fusion of dance moves from styles like Salsa, Merengue, Reggaeton and Flamenco, and the sort of choreography you might see in a nightclub.", "../Assets/zumba.jpg"),
                new Activity("Yoga", 90, "Elena Brower", "You want to be happier, more focused and sleep better? You want to improve your balance and be more flexible? Then Yoga is the right leisure activity for you! Escape from the daily stress and strengthen your body and mind with our Yoga classes every Monday and Wednesday with our team of experienced coaches. ", "../Assets/yoga2.jpg"),
                new Activity("Karate", 150, "Chan Lee", "Karate training will improve your stamina, strength, speed and flexibility. Because of the intensity of the training karate will improve your overall fitness and body awareness. Karate training will strengthen and develop almost every muscle in your body.", "../Assets/karate2.jpg")
             };
        }
        
    }
}
