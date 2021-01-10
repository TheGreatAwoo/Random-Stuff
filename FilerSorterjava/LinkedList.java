public class LinkedList{ 

  
public LinkedList(int I, String S, LinkedList Next2){
  Value =I;
  Other=S;
  Next=Next2;
} 




LinkedList Next;

int Value = -999;
String Other = null;

public void SetData(int I, String S){
  Value =I;
  Other=S;
return;}


public int getValue(){return Value;}
public String getOther(){return Other;}

public void SetNext(LinkedList x){
Next=x;
return;}

}