import java.util.HashSet;

public class Course {

    private int id;
    private String name = "";
    private Science science;
    private HashSet<Lesson> startingLessons = new HashSet<Lesson>();
     public int getId() {
         return id;
     }

     public void setId(int id) {
         this.id = id;
     }

     public String getName() {
         return name;
     }

     public void setName(String name) {
         this.name = name;
     }

     public Science getScience() {
         return science;
     }

     public void setScience(Science science) {
         this.science = science;
     }

     public HashSet<Lesson> getStartingLessons() {
         return startingLessons;
     }

     public void addStartingLesson(Lesson lesson) {
         startingLessons.add(lesson);
     }

     public void removeStartingLesson(Lesson lesson) {
         startingLessons.remove(lesson);
     }


}
