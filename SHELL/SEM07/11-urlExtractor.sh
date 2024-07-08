#!/bin/bash

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																									#
# Task:																																						#
#																																									#
# Create a script (shell, sed) that extracts all URL addresses 										#
# from a given HTML document (that is values of HREF attributes of every element) #
#																																									#
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

if [[ "$#" -lt 1 ]]; then
  echo "file not specified"
  exit 1
fi

sed -n '/<a/{s/.*href *= *["'\'']\?\([^ "'\'']*\).*/\1/p}' "$@"
