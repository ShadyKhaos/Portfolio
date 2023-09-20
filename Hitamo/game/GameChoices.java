package game;

import java.util.ResourceBundle;


public class GameChoices {

	private Storage Node45 = new Storage();
	private Storage Node34 = new Storage();
	private Storage Node70 = new Storage();
	private Storage Node24 = new Storage();
	private Storage Node38 = new Storage();
	private Storage Node62 = new Storage();
	private Storage Node80 = new Storage();
	private Storage Node21 = new Storage();
	private Storage Node27 = new Storage();
	private Storage Node37 = new Storage();
	private Storage Node41 = new Storage();
	private Storage Node79 = new Storage();
	private Storage Node82 = new Storage();
	private Storage Node26 = new Storage();
	private Storage Node28 = new Storage();
	private Storage Node81 = new Storage();
	private Storage Node83 = new Storage();
	
	void initFromPropBundle() {
		// so we're expecting a file in our CLASSPATH called
		// PropertyBundleDemo.properties
		ResourceBundle bundle = ResourceBundle.getBundle("GameChoices");
		
		String names[] = {"Node45","Node34","Node70","Node24","Node38","Node62", 
	    		"Node80","Node21","Node27","Node37","Node41","Node79","Node82","Node26",
	    		"Node28","Node81","Node83"};
		Storage sArr[] = {Node45,Node34,Node70,Node24,Node38,Node62, 
	    		Node80,Node21,Node27,Node37,Node41,Node79,Node82,Node26,
	    		Node28,Node81,Node83};
		
        for(int i = 0;i<names.length;i++) {
        	if (bundle.containsKey(names[i])) {
        		sArr[i].story = bundle.getString(names[i]);
        	}
        	if (bundle.containsKey(names[i]+"L")) {
        		sArr[i].lText = bundle.getString(names[i]+"L");
        	}
        	if (bundle.containsKey(names[i]+"R")) {
        		sArr[i].rText = bundle.getString(names[i]+"R");
        	}
        	if (bundle.containsKey(names[i]+"T")) {
        		sArr[i].type = bundle.getString(names[i]+"T");
        	}
        
        }
		
	}

	public Storage[] stringArr()
	{
		Storage[] stringArr = {Node45,Node34,Node70,Node24,Node38,Node62, 
	    		Node80,Node21,Node27,Node37,Node41,Node79,Node82,Node26,
	    		Node28,Node81,Node83};
	
		return stringArr;	
	}

} 
class Storage {

	public String story;
	public String lText;
	public String rText;
	public String type;
	
	public Storage() {
	}
}
