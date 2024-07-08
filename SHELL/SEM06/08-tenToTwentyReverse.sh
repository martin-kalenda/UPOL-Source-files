#!/bin/bash

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																																							#
# Task:																																																				#
#																																																							#
# Create a sed script that filters only lines 10 to 20 (included) from given text and prints them in reverse	#	#																																																							#
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

if [[ "$#" != 1 ]]; then
  echo "file not specified or wrong number of arguments"
  exit 1
fi

sed -n '10!G;h;20p' "$1"
