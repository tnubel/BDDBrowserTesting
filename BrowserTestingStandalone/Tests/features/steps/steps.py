import urllib2

import smtplib
from email.mime.text import MIMEText
from behave import when

from behaving.web.steps import *
from behaving.sms.steps import *
from behaving.mail.steps import *
from behaving.personas.steps import *
from behaving.personas.persona import persona_vars

from random import *;

randomNames = [ "Adam", "Beatrice", "Chris", "Dana", "Ed" , "Frank", "Georgia", "Humphrey", "Iris","Jack","Kira","Leo","Monica","Ned","Odessa","Phil","Quincy","Riley","Susan","Ted","Ulysses","Veronica","Wendy","Xerxes","Yolanda","Zack" ];

@step(u'I press the button "{name}"')
@persona_vars
def i_press_button(context, name):
    button = \
        context.browser.find_by_xpath(u"//input[@value='%s']" % name)
    assert button, u'Button with value %s not found. If you are not matching by value use "press"' % name
    button.first.click()

@step(u'I click the link "{id}"')
@persona_vars
def i_press_button(context, id):
    button = \
        context.browser.find_by_id(id)
    assert button, u'Link with id %s not found.' % name
    button.first.click()
	
@step(u'I fill in the form field "{id}" with a random name')
@persona_vars
def i_fill_in_random_name(context, id):
	field = context.browser.find_by_id(id) or \
        context.browser.find_by_name(id).first
	assert field, u'Field with id %s not found.' % id
	randomStr = choice(randomNames);
	field.type(randomStr)

@step(u'I fill in the form field "{id}" with a random SSN')
@persona_vars
def i_fill_in_random_name(context, id):
	field = context.browser.find_by_id(id) or \
        context.browser.find_by_name(id).first
	assert field, u'Field with id %s not found.' % id
	randomStr = choice(randomNames);
	field.type(randint(100000000,999999999))
		
	
	
@step(u'I fill in the form field "{id}" with "{value}"')
@persona_vars
def i_fill_in_random_name(context, id,value):
	field = context.browser.find_by_id(id) or \
        context.browser.find_by_name(id).first
	assert field, u'Field with id %s not found.' % id
	context.browser.execute_script("document.getElementById('%s').style.display='block'" % id);
	field.type(value)
	
@step(u'I check the box "{label}"')
@persona_vars
def i_check_the_box(context,label):
	field = context.browser.find_by_xpath("//label[@class='checkbox']")
	# and (contains(em/text(),'"+label+"') or contains(text(),'"+label+"'))
	for f in field:
		print(f.text);
		if (f.text == label):
			f.check();
	
	
	
@step(u'I fill in "{id}" and "{confirmid}" with a random email address')
@persona_vars
def i_fill_in_random_email(context,id,confirmid):
	field1 = context.browser.find_by_id(id) or \
        context.browser.find_by_name(id).first
	field2 = context.browser.find_by_id(confirmid) or \
        context.browser.find_by_name(id).first
	assert field1, u'Field with id %s not found.' % id
	assert field2, u'Field with id %s not found.' % confirmid
	
	randomEmail = "fakeemail+" + choice(randomNames)  + choice(randomNames)  + choice(randomNames) + str(randint(0,9999))+"@fake123email.tst"
	field1.type(randomEmail)
	field2.type(randomEmail)
