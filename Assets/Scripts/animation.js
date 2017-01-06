

function OnMousePress () {
 	yield WaitForSeconds (10);
    GetComponent.<Animation>().Play("open");
    GetComponent.<Animation>().Play("close");
}
