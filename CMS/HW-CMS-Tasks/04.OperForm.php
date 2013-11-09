<html>
<head>
	<title>04.Task-PHP And JS Form operations and validation</title>
    <script type="text/javascript">
            function isEmpty(str) {
                return (!str || str.length === 0);
            }
            function validateForm() {
                var num1 = document.forms["calculation"]["Num1"].value;
                var num2 = document.forms["calculation"]["Num2"].value;
                var oper = document.forms["calculation"]["Oper"].value;
                
                if(isNaN(num1) || isEmpty(num1)) {
                    alert("Please provide a number for first argument");                    
                    return false;
                }
                if(isNaN(num2) || isEmpty(num2)) {
                    alert("Please provide a number for second argument");
                    return false;
                }
                if(oper != '*' && oper != '+' && oper != '-' && oper != '/') {
                    alert("Please provide a valid mathematical symbol (*, +, -, /)");                    
                    return false;
                }
            }
    </script>        
</head>
<body>

<form method="GET" name="calculation" action=""  onsubmit="return validateForm()">
	<input type="text" name="Num1" />
	<input type="text" name="Oper" />
	<input type="text" name="Num2" />	
	<input type="submit" name="Submit" value="="/>
		<?php 
		if (! empty($_GET['Num1']) && ! empty($_GET['Oper']) && ! empty($_GET['Num2']))	{
				$num1=$_GET['Num1'];
				$num2=$_GET['Num2'];
				$oper=$_GET['Oper'];
				
				$accepted_signs = array( '+', '-', '*', '/' );

				if (is_numeric($num1) && is_numeric($num2) && in_array($oper, $accepted_signs))	{					
					switch ($oper) {
						case '+': $result=$num1+$num2;break;
						case '-': $result=$num1-$num2;break;
						case '*': $result=$num1*$num2;break;
						case '/': $result=$num1/$num2;break;						
					}
					echo $result;
				} else  {
					echo "Whrong number or operation!";
				}	
		}	else	{	
				echo "Operations with zero are not allowed!";	
		}
			
	?>
</form>
</body>
</html>
