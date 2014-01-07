import os
import datetime
import behaving
from behaving import environment as benv


def before_all(context):
	#benv.before_all(context);
    pass

def after_all(context):
    #benv.after_all(context)
	pass
	
def before_feature(context, feature):
    benv.before_feature(context, feature)
    benv.before_all(context)

def after_feature(context, feature):
    benv.after_feature(context, feature)
    benv.after_all(context)

#def before_scenario(context, scenario):
#    benv.before_scenario(context, scenario)


def after_scenario(context, scenario):
	
	str = '%(a)s-%(b)s'  % { "a":scenario.name ,"b":datetime.datetime.now().strftime('%x%X') }
	filename = "".join([x if x.isalnum() else "_" for x in str])
	if context.failed:	
		context.browser.driver.save_screenshot('screenshots/ERROR-%s.png' % filename)
		print('     [Screenshot of error saved at: screenshots/ERROR-%s.png]' % filename)	
	else:
		context.browser.driver.save_screenshot('screenshots/COMPLETE-%s.png' % filename)
		