<?php
	
	$con = mysqli_connect('sql4.5v.pl','pietrek19_zaliczeniesqlunity','Pi@trek15','pietrek19_zaliczeniesqlunity');
	// check that connection happend
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 - connection failed
		exit();
	}
	
	$username = $_POST["username"];
	$question = $_POST["question"];
	$answer = $_POST["playerAnswer"];
	
	$idpquery = "SELECT idp FROM players WHERE username ='".$username."';";
	
	$idpresult = mysqli_query($con,$idpquery);
	$idprow = mysqli_fetch_row($idpresult);
	
	$idp = $idprow[0];
	$idp = (int)$idp;
	
	$question = (int)$question;
	$answer = (int)$answer;

	
	$insertuserquery = "INSERT INTO history (idp, idq, answer) VALUES ('".$idp."','".$question."','".$answer."');";

	mysqli_query($con,$insertuserquery) or die("2: Insert history query failed");//error code #4 - insert query failed
	
	echo("0");
?>