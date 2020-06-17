<?php

	$con = mysqli_connect('sql4.5v.pl','pietrek19_zaliczeniesqlunity','Pi@trek15','pietrek19_zaliczeniesqlunity');
	// check that connection happend
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 - connection failed
		exit();
	}
	
	$username = $_POST["username"];
	$icon =$_POST["icon"];
	$sql = "update profiles join players on idpp = idp set icon = '".$icon."' where username = '".$username."';";
	
	mysqli_query($con,$sql) or die("2: Insert query failed");//error code #2 - name check query failed
	echo("0");

?>