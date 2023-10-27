
import java.util.HashSet;

public class Explanation {
    private int id;
    private String name = "";
    private Explanation prev;
    private HashSet<Explanation> next = new HashSet<Explanation>();
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

    public Explanation getPrev() {
        return prev;
    }

    public void setPrev(Explanation prev) {
        this.prev = prev;
    }

    public HashSet<Explanation> getNext() {
        return next;
    }

    public void setNext(HashSet<Explanation> next) {
        this.next = next;
    }
    public void setNext(HashSet<Explanation> next) {
        this.next = next;


}