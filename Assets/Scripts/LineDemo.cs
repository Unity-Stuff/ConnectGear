using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineDemo : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
	public LineFactory lineFactory;

	private Vector2 start;
	private static Line drawnLine;

	public int maxOutLines;
	public int maxInLines;
	Line[] outgoingLines;
	public int countOutLines;
	public int countInLines;

	public int lineDrawPermission;

	GameObject[] gearsList;


	private static List<GameObject> connectingGears;

	static Vector3 startPos;
	Vector3 currentPos;
	float lineLength;

	LineDemo gearLine;


	void Start(){
		
		countOutLines=0;
		countInLines=0;
		outgoingLines= new Line[maxOutLines];
		gearsList=GameObject.FindGameObjectsWithTag("Gear");
		connectingGears=new List<GameObject>();
		connectingGears.Add(GameObject.Find("RootGear").gameObject);

	}
	void Update ()
	{
		Vector3 currentPos=Camera.main.ScreenToWorldPoint (Input.mousePosition);
		lineLength=Vector3.Distance(startPos, currentPos);
		if (drawnLine != null && lineLength<2) {
			
			drawnLine.end = Camera.main.ScreenToWorldPoint (Input.mousePosition); // Update line end

		}
	}
	public void OnPointerDown(PointerEventData eventData)
    {
        StartLine();
    }



	public void OnPointerEnter(PointerEventData eventData)
    {
        if(drawnLine!=null){
        	StartLine();

        	}
    }
	public void OnPointerUp(PointerEventData eventData)
    {
        if(drawnLine!=null)
        	StartLine();
		
    }

	public void StartLine(){
		if(drawnLine!=null && lineDrawPermission==1){ // check that the line is not connecting the same object
			drawnLine=null;
			outgoingLines[--countOutLines].gameObject.SetActive(false);
		}
		else if(drawnLine!=null && countInLines<maxInLines){ //check if line drawing is process and incoming no. lines has not exceeded 
			if(connectingGears.Count<2 || connectingGears[connectingGears.Count-2]!=gameObject) //To prevent out of bounds error and To ensure that the gear is not connecting to the previous gear 
				EndLine();
			}

		else if(countOutLines==maxOutLines && drawnLine==null){
			Clear();
		}
		else if(lineDrawPermission==1){
			var pos = Camera.main.ScreenToWorldPoint (transform.position);
			startPos=pos;
			drawnLine = lineFactory.GetLine (pos, pos, 0.03f, Color.white);

			outgoingLines[countOutLines++]=drawnLine.GetComponent<Line>();
			}

	}

	public void EndLine(){
				Vector3 currentPos=Camera.main.ScreenToWorldPoint(transform.position);
				lineLength=Vector3.Distance(startPos, currentPos);
				if(lineLength<2.5){
					drawnLine.end = Camera.main.ScreenToWorldPoint (transform.position);
					drawnLine = null;
					SetPermission();
					countInLines++;
					connectingGears.Add(gameObject);
					ButtonSoundPlayer.instance.PlayGearClip();
				}
	}

	/// <summary>
	/// Get a list of active lines and deactivates them.
	/// </summary>
	public void Clear()
	{
//		var activeLines = lineFactory.GetActive ();
		
		ClearLines();
		SetPermission();
		countOutLines=0;

		int currentPos=connectingGears.IndexOf(gameObject);
		for(int i=connectingGears.Count-1;i>currentPos;i--){
			gearLine=connectingGears[i].GetComponent<LineDemo>();
			int multipleInstanceFlag=0; // If multi input gears connect each other in a loop
			for(int j=0;j<currentPos;j++){
				if(connectingGears[i]==connectingGears[j]){
					multipleInstanceFlag=1;
					break;
				}
			}


			Debug.Log(connectingGears[i]+":multipleInstanceFlag:"+multipleInstanceFlag);
			if(multipleInstanceFlag==1){
//				Debug.Log(gameObject+":countOutgoingLines: "+countOutgoingLines);
					gearLine.countInLines--;
//					gearLine.countOutLines--;
					gearLine.ClearLinesMulti();
			}
			else{
				
			gearLine.countOutLines=0;
			gearLine.countInLines=0;
			gearLine.ClearLines();
			}
			Debug.Log("Connectgears remove at"+connectingGears[i]);
			connectingGears.RemoveAt(i);

		}
		if(maxInLines>0) //To ensure that countInLines of Root gear is not set to 1
			countInLines=1; //To ensure that multi input gears do not initialize to zero in lines.
	}
	public void ClearLines(){
	Debug.Log(gameObject+" :Clear Lines");
	if(outgoingLines[0]!=null){ //check it is not the last connected gear
		foreach (var line in outgoingLines) {
			if(line!=null){
				
				line.gameObject.SetActive(false);
				}

		}
	
		}
	}

	public void ClearLinesMulti(){
		
	if(outgoingLines[0]!=null){ //check it is not the last connected gear
		int countOutgoingLines=0;
		for(int i=outgoingLines.Length-1;i>=0;i--){
		
		if(outgoingLines[i]!=null){
			if(outgoingLines[i].gameObject.activeSelf==true)
				countOutgoingLines++;
			}
		}
		Debug.Log(gameObject+" Outgoing Lines:"+countOutgoingLines);

		for(int i=outgoingLines.Length-1;i>=0;i--){
			
			if(outgoingLines[i]!=null){
					if(outgoingLines[i].gameObject.activeSelf==true){
						if(countOutgoingLines==1)
							break;
						outgoingLines[i].gameObject.SetActive(false);
						countOutgoingLines--;
						countOutLines--;

				}
			}
		}
	
		}
	}

	void SetPermission(){
		foreach(GameObject gear in gearsList){
					LineDemo gearLine2=gear.GetComponent<LineDemo>();
					gearLine2.lineDrawPermission=0;
				}
				lineDrawPermission=1;
		}

}

