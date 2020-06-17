<?php
	
	$con = mysqli_connect('sql4.5v.pl','pietrek19_zaliczeniesqlunity','Pi@trek15','pietrek19_zaliczeniesqlunity');
	// check that connection happend
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 - connection failed
		exit();
	}
	
	
	$sql = "SELECT catname FROM category ORDER BY idc;";
	
	$result = mysqli_query($con,$sql) or die("2: Name check query failed");//error code #2 - name check query failed
	
	echo("0");
	
	if(mysqli_num_rows($result)>0)
	{
		while($row = mysqli_fetch_assoc($result))
		{
			echo "\t".$row["catname"];
		}
	}
	
	
	
?>