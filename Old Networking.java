import java.net.*;
import java.io.*;
import java.util.*;
public class assignment4 {

	public static void main(String[] args) throws IOException {
		
		
		 MulticastSocket s = new MulticastSocket(40202);
		 assignment4session Sess = new assignment4session(s);
		 InetAddress Inet ;
		 Inet =  InetAddress.getByName("239.0.202.1");
		 Sess.start();
		 while(true) {
		String out = System.console().readLine(); 
		if(out!=null) {DatagramPacket Pack = new DatagramPacket(out.getBytes(),out.length(),Inet,40202);
		s.send(Pack);
		}
		 }
	}

}

 class assignment4session extends Thread{
	 MulticastSocket Multi;
	 InetAddress Inet ;
	 byte[] BA = new byte[999];
	public void run(){
		try {
			Inet =  InetAddress.getByName("239.0.202.1");
			Multi.joinGroup(Inet);
			while(true){
			DatagramPacket Data = new DatagramPacket(BA,BA.length);	
			Multi.receive(Data);
			System.out.println(Data.getAddress().getHostAddress().toString()+": "+ new String(Data.getData(),Data.getOffset(),Data.getLength()));
			}
	}
	
		catch(Exception e) {
		    System.err.println("Exception: " + e);}
		}
	
	public assignment4session(MulticastSocket MultiC) {
		Multi = MultiC;}
	
	}