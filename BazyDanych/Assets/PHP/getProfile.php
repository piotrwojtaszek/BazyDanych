<?php

	$con = mysqli_connect('sql4.5v.pl','pietrek19_zaliczeniesqlunity','Pi@trek15','pietrek19_zaliczeniesqlunity');
	// check that connection happend
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 - connection failed
		exit();
	}
	
	$username = $_POST["username"];
	
	$sql = "SELECT icon FROM profiles JOIN players ON idpp = idp WHERE username = '".$username."';";
	
	$result = mysqli_query($con,$sql) or die("2: Name check query failed");//error code #2 - name check query failed
	

	
	$result = mysqli_query($con,$sql);
	$row = mysqli_fetch_row($result);
	echo("0");
	echo "\t".$row[0];

?>