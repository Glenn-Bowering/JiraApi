# LinqPad Quick Start Giude

This is a quickstart guide to using the JiraApi library with LinqPad. LinqPad offers something akin to a scripting environment for C#. LinqPad in conjunction with JiraApi offers a powerful way of querying and understanding your Jira data.

This guide will show you how to set up the assembly with LinqPad and run a JQL query against your Jira installation.

## Referncing the JiraApi Assembly

In order to use the JiraApi assembly within a LinqPad script you need to have referenced it. 

Click on Query|Reference and Properties or press the F4 key to display the "Query Properties" dialog. 

![](img/refernce_assembly_linqpad.png)

On the "Additional Refernces" click the add button and then click browse. Find the JiraApi assembly.

![](img/query_properties_linqpad.png)

On the "Query Properties" tab add the following namespaces:

* `Jira`
* `Jira.Api`
* `Jira.Api.ObjectModel`

You should now be able to use the JiraApi in your script. 

**Note:** You will need to do this for every script you create.

## Your first Script

Select `File|New` to create a new script. From the language dropdown choose C# Program.

![](img/script_selection_linqpad.png)

In order to create a `JiraClient` object you'll need to define a server string and a `JiraCredentials` object (see below).

![](img/constructor.png)

Next you'll need to build a `SearchCommand` and an `ApiRequest` object. The `SearchCommand` is a parameter of the `ApiRequest` object. The `ApiRequest` can be built with an `ApiRequestBuilder` object. The code below shows the important properties which need to be set.

![](img/request_builder.png)

Once you execute the request with the `request` object you will have a list of issues (`List<Issue>`). The `Issue` class represents a Jira Issue and has the following properties.

The `Issue` class has the following properties. Most of which are standard Jira Issue fields.

![](img/issue_class.png)

The exceptions are the LeadTime and Transitions properties. The LeadTime property currently has a bug causing it to return incorrect value and should be ignored. 

The Transitions property will show all the different states that this issue has been in since it's creation. You must use `request.WithExpansion("changelog")` when building the `ApiRequest` object in order for the transitions to be populated.

Once you have a list of issues you can then perform other manipulations in order to answer you questions about your Jira data.

The code below show how you can filter a list of issues that contain the word 'update'. An example is given showing how a linq query can be used as well as a foreach loop.

![](img/query_code.png)

Finally, LinqPad adds the `Dump()` method to every object. The `Dump()` displays the state (contents) of an object in LinqPad's viewer pane. Calling dump on a list of issues will display the whole list. The query above returns two objects which are then dumped (see below).

![](img/dump_output.png)


If you're using Linq you can select fewer fields in the returned object. 

![](img/linq_with_projection.png)

This makes the data returend more manageable.

![](img/dump_output_reduced.png)
