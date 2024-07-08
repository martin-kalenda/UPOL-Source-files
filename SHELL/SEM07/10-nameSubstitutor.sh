#!/bin/bash

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																																							#
# Task:																																																				#
#																																																							#
# Write a script (shell, sed) that for every line on STDIN in the format "Name Surname <email@address>"				#
# creates a copy of a text file (a template) given as an argument.																						#
# 																																																						#
# In this copy every occurence of the strings JMENO and PRIJMENI will be replaced by Name and Surname					#
# and <email@address> will be written on a separate line at the beginning of the file followed by a newline.	#
#																																																						  #
# Copied files will be named "templateNameX" where X is the line number for which the substitution was done.  #
#																																																							#
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

line=0

if [[ "$#" -ne 1 ]]; then
  echo "template not specified"
  exit 1
fi

#read line from input, split it into 3 variables
while read name surname email; do
  ((line=line+1))
  #create output file name
  output="$1$line"
  #create output file from template
  cp "$1" "$output"
  #replace all occurences of JMENO and PRIJMENI in template copy and insert email
  sed -i "s/JMENO/$name/g; s/PRIJMENI/$surname/g; 1i$email\n" "$output"
done
