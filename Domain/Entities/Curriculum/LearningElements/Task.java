
import java.util.HashSet;

public class Task {
    private int id;
    private String name = "";
    private Task prev;
    private HashSet<Task> next = new HashSet<Task>();
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

    public Task getPrev() {
        return prev;
    }

    public void setPrev(Task prev) {
        this.prev = prev;
    }

    public HashSet<Task> getNext() {
        return next;
    }

    public void setNext(HashSet<Task> next) {
        this.next = next;
    }

}