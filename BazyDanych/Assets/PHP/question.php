<?php
	
	$con = mysqli_connect('sql4.5v.pl','pietrek19_zaliczeniesqlunity','Pi@trek15','pietrek19_zaliczeniesqlunity');
	// check that connection happend
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 - connection failed
		exit();
	}
	
	$username = $_POST["username"];
	$time = $_POST["time"];
	$category = $_POST["category"];
	$content = $_POST["content"];
	$correct = $_POST["correct"];
	$aa = $_POST["aa"];
	$ab = $_POST["ab"];
	$ac = $_POST["ac"];
	$ad = $_POST["ad"];
	
	//check if name exist
	
	$namecheckquery = "SELECT content FROM questions WHERE content ='".$content."';";
	
	$namecheck = mysqli_query($con,$namecheckquery) or die("2: Name check query failed");//error code #2 - name check query failed
	
	if(mysqli_num_rows($namecheck)>0)
	{
		echo "3: Name already exists";//error code #3 - name exists cannot register
		exit();
	}
	// add question to the table
	// get category id
	$catquery = "SELECT idc FROM category WHERE catname ='".$category."';";
	
	$catresult = mysqli_query($con,$catquery);
	$catrow = mysqli_fetch_row($catresult);
	
	$idc = $catrow[0];
	$idc = (int)$idc;
	
	// get player id
	$playerquery= "SELECT idp FROM players WHERE username ='".$username."';";
	$playerresult = mysqli_query($con,$playerquery);
	$playerrow = mysqli_fetch_row($playerresult);
	
	$idp = $playerrow[0];
	$idp = (int)$idp;
	
	// convert time STRING to INT
	$time = (int)$time;
	
	// finally add ne question to database
	$insertuserquery = "INSERT INTO questions (idp, time, idc, content, corrent, a, b, c, d) VALUES ('".$idp."','".$time."','".$idc."','".$content."','".$correct."','".$aa."','".$ab."','".$ac."','".$ad."');";

	mysqli_query($con,$insertuserquery) or die("4: Insert player query failed");//error code #4 - insert query failed
	
	echo("0");
	
?>