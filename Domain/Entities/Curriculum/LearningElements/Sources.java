
import java.util.HashSet;

public class Sources {
    private int id;
    private String name = "";
    private Sources prev;
    private HashSet<Sources> next = new HashSet<Sources>();
    private LearningElements startingElement;

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

    public void setPrev(Sources prev) {
        this.prev = prev;
    }

    public Sources getPrev() {
        return prev;
    }


    public HashSet<Sources> getNext() {
        return next;
    }

    public void setNext(HashSet<Sources> next) {
        this.next = next;
    }
    public HashSet<Sources> getNext() {
        return next;
}