import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.BufferedReader;
import java.io.FileReader;

public class FileSort {
    
  
  public static void main(String[] args) throws Exception{
    
    LinkedList Head  = new LinkedList(-999,null,null);
    LinkedList Current=Head; 
    String srcFile = "test.txt";
    BufferedReader br = new BufferedReader(new FileReader(srcFile));
    String text = null;
    int Size=1;
    
    try {

    if ((text = br.readLine()) != null) {
    String Line[] = text.split(",");  
    int i = Integer.parseInt(Line[0]);
    Current.SetData(i,Line[1]);
   
      
    while ((text = br.readLine()) != null) {
    String LineT[] = text.split(",");  
    i = Integer.parseInt(LineT[0]);
    LinkedList Next  = new LinkedList(i,LineT[1],null);
    Current.SetNext(Next);
    Current=Current.Next;
    Size++;
    }}}
    catch (NullPointerException e) {
      System.out.println("Adding To List Error");}
    //____________________________________________________________________________________________________________________Sorting List
    br.close();
  
    
    try{
    
    int Loop=1;
      
   while(Loop>0){
     Current=Head;
     Loop=0;
  
   for(int y=0;y<Size;y++){
     if(Current.Next!=null){  
   int ValueC = Current.getValue();
   int ValueN = Current.Next.getValue();
   String OtherC = Current.getOther();
   String OtherN = Current.Next.getOther();
   
   if(ValueC>ValueN){
   Current.SetData(ValueN,OtherN);
   Current.Next.SetData(ValueC,OtherC);
   Loop++;}
   Current=Current.Next;
   
     }}}}
    catch (NullPointerException e) {System.out.println("Sorting Error");}
    
 
    //____________________________________________________________________________________________________________________Write
    
    String destFile = "testOutput.txt";
    try{
      BufferedWriter bw = new BufferedWriter(new FileWriter(destFile));
      Current=Head;
   for(int y=0;y<Size;y++){
      bw.write(Current.getValue()+","+Current.getOther());
      bw.newLine();
      Current=Current.Next;
    } 
  // Current=Current.Next;
 //  bw.write(Current.getValue()+","+Current.getOther());
              bw.flush();
              }catch (Exception e2) {System.out.println("Writing Error");}
}//Main

//Test(Head,Size);
  public static void Test(LinkedList Head,int Size){
    LinkedList Current = Head;
    for(int y=0;y<Size;y++){
    int x=Current.getValue();
    System.out.println(x);
    Current=Current.Next;}}
  
  
  
  
  
  
  }



