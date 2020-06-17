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
	
	$namecheckquery = "SELECT username, password FROM players WHERE username ='".$username."';";
	
	$namecheck = mysqli_query($con,$namecheckquery) or die("2: Name check query failed");//error code #2 - name check query failed

	if(mysqli_num_rows($namecheck) !=1)
	{
		echo"5: Either no user with name, or more than one"; //error code #5 - number of names matching !=1
		exit();
	}
	
	// get login info from query
	$existingInfo = mysqli_fetch_assoc($namecheck);
	$correctPassword = $existingInfo["password"];
	
	if($correctPassword != $password)
	{
		echo "6: Inccorect password";//error code #6 - inncorect password
		exit();
	}
	
	echo("0");
	
?>