# todo &mdash; an idiosyncratic todo list manager

This project is a small C# solution which manages todo lists written in Markdown.

Over the next couple of weeks, I will flesh out this Readme file with a description of how it should be used and a full list of features.

In the meantime, build the app and run `todo help` from the command line to see a full list of commands.

Please feel free to DM me on Twitter, [@PDWhittington](https://twitter.com/PDWhittington), or to add issues for any features you would like to see.

Thanks,

Phil Whittington

<table>
<tr>
<th>
Command
</th>
<th>
Description
</th>
</tr>
<tr>
<td>
createorshow
</td>
<td>
Creates or shows a markdown file for the date supplied. This is the default command and can be executed by typing anything that can be parsed as a date. Supplying no date assumes the current day.<br/><br/>                                                             
Usage: todo [date]                                           
</td>
</tr>
<tr>
<td>
a<br/>
archive
</td>
<td>
Archives the markdown file for a given date. The file is moved into the archive subfolder of the main todo folder. The name of the archive folder is specified in settings.json. Also in settings.json can be specified whether the file is moved simply in the file system, or by using git mv.<br/><br/>
Usage: todo a [date]
</td>
</tr>
<tr>
<td>
c<br/>
commit
</td>
<td>
Gathers the current modifications into a commit. Commit message is optional.<br/><br/>
Usage: todo c [commit message]                                
</td>
</tr>
<tr>
<td>
h<br/>
html<br/>
showhtml
</td>
<td>
Opens the browser specified in the settings file and loads the Html file for the given date. <br/><br/>
Usage: todo h [date]
</td>
</tr>
<tr>
<td>
help<br/>
about            
</td>
<td>
Displays this help screen.<br/><br/>
Usage: todo help             
</td>
</tr>
<tr>
<td>
i<br/>
init
</td>
<td>
Initialises the current folder with a default todo-settings.json file.<br/><br/>
Usage: todo init                             
</td>
</tr>
<tr>
<td>
k<br/>
killhtml
</td>
<td>
Deletes all the html files in the todo folder and the archive subfolder<br/><br/>
Usage: todo k                                               
</td>
</tr>
<tr>
<td>
l<br/><br/>
list
</td>
<td>
Provides a list of all todo lists. Switches are as follows:-<br/><br/>
<ul>
<li>m -- main todo folder.</li>
<li>a -- archive folder.</li>
<li>d -- lists relating to days.</li>
<li>t -- lists relating to topics.</li>
</ul><br/><br/>
Usage: todo l [m | a] [d | t]
</td>
</tr>
<tr>
<td>
p<br/>
print<br/>
printhtml<br/>
</td>
<td>
Converts a Markdown file to HTML. Can be used with anything that can be parsed as a date. Supplying no date performs this operation on the Markdown file for the current day.<br/><br/>
Usage: todo p [date]                                         
</td>
</tr>
<tr>
<td>
ph<br/>
printandshowhtml
</td>
<td>
This command is equivalent to printhtml followed by showhtml (p, h).<br/><br/>
Usage: todo ph [date]
</td>
</tr>
<tr>
<td>
push
</td>
<td>
Executes a git push.<br/><br/>
Usage: todo push
</td>
</tr>
<tr>
<td>
rm<br/>
remove<br/>
delete
</td>
<td>
Deletes the file. If git is enabled, the command performs a
remove in git.<br/><br/>
Usage: todo rm [date]
</td>
</tr>
<tr>
<td>
s<br/>
sync
</td>
<td>
Executes a commit and push operation sequentially.<br/><br/>
Usage: todo s [commit message]
</td>
</tr>
<tr>
<td>
sc<br/>
showconflicts
</td>
<td>
Opens in the text editor all of the files for which conflicts exist<br/><br/>
Usage: todo sc
</td>
</tr>
<tr>
<td>
settings<br/>
showsettings
</td>
<td>
Shows the settings file in the default editor.<br/><br/>
Usage: todo settings
</td>
</tr>
<tr>
<td>
t<br/>
topic
</td>
<td>
Creates or shows a todo list relating to a single topic.<br/><br/>
Usage: todo t (topic name)
</td>
</tr>
<tr>
<td>
u<br/>
unarchive
</td>
<td>
Un-archives the markdown file for a given date. The file is moved form the subfolder back to the main todo folder. The name of the archive folder is specified in settings.json. Also in settings.json can be specified whether the file is moved simply in the file system, or by using git mv.<br/><br/>
Usage: todo u [date]                                      
</td>
</tr>
<table>

Notes:

createorshow is the default command. This means it can be accessed simply by
typing anything that can be parsed as a date after the word todo.

Valid date formats:-

   "y", "yesterday"  yesterday
   [empty string], ".", "today"  today
   "tm", "tomorrow"  tomorrow
   [day]  maps to the day/month/year which is nearest in time to today
   [day]/[month]  maps to the day/month which is nearest in time to today
   +[daycount]  positive offset a number of days from today
   -[daycount]  negative offset a number of days from today

[Commit Message]  In the Commit and Sync commands, the commit message is
optional. If none is supplied, then a standard message detailing date and time
of the commit will be used.

