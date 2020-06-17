<?php
	
	$con = mysqli_connect('sql4.5v.pl','pietrek19_zaliczeniesqlunity','Pi@trek15','pietrek19_zaliczeniesqlunity');
	// check that connection happend
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 - connection failed
		exit();
	}
	
	$username = $_POST["name"];
	$password = $_POST["password"];
	
	//check if name exist
	
	$namecheckquery = "SELECT username FROM players WHERE username ='".$username."';";
	
	$namecheck = mysqli_query($con,$namecheckquery) or die("2: Name check query failed");//error code #2 - name check query failed
	
	if(mysqli_num_rows($namecheck)>0)
	{
		echo "3: Name already exists";//error code #3 - name exists cannot register
		exit();
	}
	// add user to the table
	
	$insertuserquery = "INSERT INTO players (username, password) VALUES ('".$username."','".$password."');";

	mysqli_query($con,$insertuserquery) or die("4: Insert player query failed");//error code #4 - insert query failed
	
	echo("0");
	
?>