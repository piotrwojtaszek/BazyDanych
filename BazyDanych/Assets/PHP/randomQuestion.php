<?php
	
	$con = mysqli_connect('sql4.5v.pl','pietrek19_zaliczeniesqlunity','Pi@trek15','pietrek19_zaliczeniesqlunity');
	// check that connection happend
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 - connection failed
		exit();
	}
	
	$username = $_POST["name"];
	$category = $_POST["category"];
	// get player id
	$playerquery= "SELECT idp FROM players WHERE username ='".$username."';";
	$playerresult = mysqli_query($con,$playerquery);
	$playerrow = mysqli_fetch_row($playerresult);
	$idp = $playerrow[0];
	$idp = (int)$idp;

	
	$catquery = "SELECT idc FROM category WHERE catname ='".$category."';";
	
	$catresult = mysqli_query($con,$catquery);
	$catrow = mysqli_fetch_row($catresult);
	
	$idc = $catrow[0];
	$idc = (int)$idc;
	
	
	$catquery="";
	
	if($idc==1)
	{
		$catquery = "SELECT questions.* FROM questions WHERE '".$idp."'!= questions.idp ORDER BY RAND()LIMIT 1;";
	}
	else
	{
		$catquery = "SELECT questions.* FROM questions WHERE '".$idp."'!= questions.idp AND idc = '".$idc."' ORDER BY RAND()LIMIT 1;";
	}
	
	$catresult = mysqli_query($con,$catquery);
	$catrow = mysqli_fetch_row($catresult);
		
	echo("0");
	echo "\t".$catrow[0]."\t".$catrow[1]."\t".$catrow[2]."\t".$catrow[3]."\t".$catrow[4]."\t".$catrow[5]."\t".$catrow[6]."\t".$catrow[7]."\t".$catrow[8]."\t".$catrow[9];
	
	
?>