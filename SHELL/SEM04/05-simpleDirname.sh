#!/bin/bash

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																																															#
# Task:																																																												#
#																																																															#
# Implement a simplified version of the dirname program:																																			#
# 	from a given path (after removing the '/' at the end), return the part from the beginning of the path up to the last '/'.	#
# 	If a path does not contain '/', return '.'.																																								#
#																																																															#
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #


#simplified version of built-in dirname function
dirname() {
  #remove possible trailing '/'
  local path="${1%/}"

  #if '/' is the only character, return it
  if [[ -z "${path%/*}" ]]; then
    echo "/"
  #if path doesn't contain slashes, return '.'
  elif [[ "$path" != *"/"* ]]; then
    echo "."
  #return path up to the last '/'
  else
    echo "${path%/*}"
  fi
}

dirname "$1"
