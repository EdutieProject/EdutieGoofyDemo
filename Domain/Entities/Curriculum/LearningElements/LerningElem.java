

public class LerningElem {
    private int id;
    private int indexOfChance;
    private String name = "";
    private LerningElem prev;
    private HashSet<LerningElem> next = new HashSet<LerningElem>();

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

    public void setPrev(LerningElem prev) {
        this.prev = prev;
    }

    public LerningElem getPrev() {
        return prev;
    }


    public void setNext(HashSet<LerningElem> next) {
        this.next = next;
    }
    public void setIndexOfChance(int indexOfChance) {
        this.indexOfChance = indexOfChance;
    }
    public HashSet<LerningElem> getNext() {
        return next;
    }

    public getTask(Task task){
        HashSet<Task> taskToDo = task.getNext();
    }
    public getExplaination(Explaination explain){
        HashSet<Explaination> ExplainTheTask = explain.getNext();
    }
    public int getIndexOfChance() {
        return indexOfChance;
    }

    public getSource(Sources source){
        HashSet<Source> sourceOfKnowledge = source.getNext();
    }
}