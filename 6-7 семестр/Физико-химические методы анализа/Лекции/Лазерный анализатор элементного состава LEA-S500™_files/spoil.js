var click1=0;
var click2=0;

function rez(id)
{
	if (id=="click1") 
	{
		if (click1==0)
		{	
			document.getElementById(id).className='closed';
			click1=1;
		}
		else
		{
			document.getElementById(id).className='opened';
			click1=0;
		}
	}
	else
	{
		if (click2==0)
		{	
			document.getElementById(id).className='closed';
			click2=1;
		}
		else
		{
			document.getElementById(id).className='opened';
			click2=0;
		}
	}
}

function spoiler(id)
{
for (var i = 1; i < 5; i++) {
var obj = "";
// ��������� ������������� ��������
if(document.getElementById)
obj = document.getElementById(id+i).style;
else if(document.all)
obj = document.all[id+i];
else if(document.layers)
obj = document.layers[id+i];
else
return 1;
// ����� �����
if(obj.display == "")
obj.display = "none";
else if(obj.display != "none")
obj.display = "none";
else
obj.display = "block";
}
}