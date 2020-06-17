<?php

	$con = mysqli_connect('sql4.5v.pl','pietrek19_zaliczeniesqlunity','Pi@trek15','pietrek19_zaliczeniesqlunity');
	// check that connection happend
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 - connection failed
		exit();
	}
	
	$filtr = $_POST["filtr"];
	$sql ="";
	if($filtr == "username")
	{
		$sql = "SELECT username,COUNT(history.idp) ,SUM(answer), AVG(answer) FROM history RIGHT JOIN players ON history.idp=players.idp GROUP BY players.idp ORDER BY username DESC;";
	}
	else if($filtr =="COUNT(history.idp)")
	{
		$sql = "SELECT username,COUNT(history.idp) ,SUM(answer), AVG(answer) FROM history RIGHT JOIN players ON history.idp=players.idp GROUP BY players.idp ORDER BY COUNT(history.idp) DESC;";
	}
	else if($filtr =="SUM(answer)")
	{
		$sql = "SELECT username,COUNT(history.idp) ,SUM(answer), AVG(answer) FROM history RIGHT JOIN players ON history.idp=players.idp GROUP BY players.idp ORDER BY SUM(answer) DESC;";
	}
	else
	{
		$sql = "SELECT username,COUNT(history.idp) ,SUM(answer), AVG(answer) FROM history RIGHT JOIN players ON history.idp=players.idp GROUP BY players.idp ORDER BY AVG(answer) DESC;";
	}

	
	$result = mysqli_query($con,$sql) or die("2: Name check query failed");//error code #2 - name check query failed
	
	echo("0");
	
	if(mysqli_num_rows($result)>0)
	{
		while($row = mysqli_fetch_assoc($result))
		{
			echo "&**&".$row["username"]."\t".$row["COUNT(history.idp)"]."\t".$row["SUM(answer)"]."\t".$row["AVG(answer)"];
		}
	}

?>