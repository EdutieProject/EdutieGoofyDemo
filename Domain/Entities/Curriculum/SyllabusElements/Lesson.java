
import java.util.HashSet;

public class Lesson {
    private int id;
    private String name = "";
    private Lesson prev;
    private HashSet<Lesson> next = new HashSet<Lesson>();
    private ILearningElement startingElement;

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

    public Lesson getPrev() {
        return prev;
    }

    public void setPrev(Lesson prev) {
        this.prev = prev;
    }

    public HashSet<Lesson> getNext() {
        return next;
    }

    public void setNext(HashSet<Lesson> next) {
        this.next = next;
    }

    public ILearningElement getStartingElement() {
        return startingElement;
    }

    public void setStartingElement(ILearningElement startingElement) {
        this.startingElement = startingElement;
    }

    public Lesson(String name) {
        this.name = name;
    }

    public getLerningElem(LerningElem elem){
        HashSet<LerningElem> ElemToDo = elem.getNext();
    }


}
