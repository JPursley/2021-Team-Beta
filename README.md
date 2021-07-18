# 2021-Team-Beta - BetaMAX

# Description 
A plug in for Acumatica that will allow the Acumatica user to share a video call with a customer. 

# Business Case 
Without integrated video it is more difficult to create sessions, more difficult to match video and customer for legal purposes, and no management review of the positive impacts. 

# Process Flow 
* Acumatica side: Start session with Vonage API and create metadata 
* Acumatica side: Send session ID and a related unique ID to the end customer in an URL via SMS 
* Client side: Connect to same session using Vonage API and track with unique ID 
* Run scenario 
* Finish session on either side 
* Update metadata entry for the session 

# Development Elements 

* Setup Screen with data entry fields for Vonage API keys
* SQL table 
* DAC 
* Screen creation 
* Sitemap + Workspace 
* Reporting 
* Table with meta data concerning calls – links to videos 
* Report/GI/Dashboard for review of activity – average length of video, missed callsd 
* Potential Extra: dashboard analysis of case rating with vs. without video call 
* Potential Extra: dashboard analysis of future sales of customers with cases with video vs. without video vs. no cases 
* Acumatica Interface Edit:
* Customize an existing screen to add our project elements 
* A start button and some text 
* Standalone page for this? Or Universal extension? 
* Webhook code to deliver single page app to the end user/client 
