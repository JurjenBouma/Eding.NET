;*****************************************
;* Custom macro file from eding.NET
;*****************************************
;*Used Variables
;*****************************************
;*find_hole_center
;*****************************************
;*#3990 is feature width/2
;*#3991 is feature height/2
;*#3992 is feature aprox center x
;*#3993 is feature aprox center y
;*#3994 is feature aprox center z
;*#3980 is X+
;*#3981 is Y+
;*#3985 is X center
;*#3986 is Y center
;*#4970 is probe feed
;*****************************************
;*find_box_center
;*****************************************
;*#3990 is box width/2
;*#3991 is box height/2
;*#3992 is box aprox center x
;*#3993 is box aprox center y
;*#3994 is save z
;*#3996 is probe z
;*#3980 is X+
;*#3981 is Y+
;*#3985 is X center
;*#3986 is Y center
;*#4970 is probe feed
;*****************************************
;*measure_tool measurement sub
;*****************************************
;*#3998 is aprox tool lenght
;*#3999 is tool number 
;*#4971 is probe feed
;*#4997 is probe x 
;*#4998 is probe y
;*#4999 is probe z
;*****************************************
;*probe_angle sub
;*****************************************
;*#3961 is x1
;*#3962 is y1
;*#3971 is x2
;*#3972 is y2
;*#3992 is save x
;*#3993 is save y
;*#3994 is save z
;*#4972 is probe feed
;*#4980 is angle
;*#4982 is probedistX
;*#4983 is probedistY
;*****************************************


;Homing per axis
Sub home_x
    ;home x
    ;;if A is slave of X uncomment next lines and comment previous line
    homeTandem X
Endsub

Sub home_y
    home y
Endsub

Sub home_z
    home z
Endsub

Sub home_a
    ;;If a is slave comment out next line
    ;;For homing a master-slave axis only homeTandem <master> should be done
    ;home a
Endsub

Sub home_b
    home b
Endsub

Sub home_c
    home c
Endsub

;Home all axes, uncomment or comment the axes you want.
sub home_all
    gosub home_z
    gosub home_y
    gosub home_x
    gosub home_a
    gosub home_b
    gosub home_c
    msg "Home complete"
endsub

;#3998 is aprox tool lenght, #3999 is tool number, #4971 is probe feed, #4997 is probe x , #4998 is probe y, #4999 is probe z
sub measure_tool 
    if [[#5380==0] and [#5397==0]] ;do this only when not simulating and not rendering
        ;Check if toolsetter is calibrated
        if [[#4997 == 0] and [#4998 == 0] and [#4999 == 0]]
            errmsg "calibrate first"
        else
            g0 g53 z0 ; move to safe z
            if [[#3999 < 1] OR [#3999 > 99]]
                errmsg "Tool must be in range of 0 .. 99"
            endif
        
            ;move to toolsetter coordinates
            g0 g53 x#4997 y#4998 
            ;move to 10mm above chuck height + approx tool length + 10
            g0 g53 z[#4999+10+#3998]
            ;measure tool length and pull 5mm back up
            g38.2 g91 z-20 f#4971
            g90
            ;back to safe height
            g0 g53 z0
            ;Store tool length in tool table
            ;but only if actually measured, 
            if [#5067 == 1]
                #[5400 + #3999] = [#5053-#4999]
                msg "tool length measured="#[5400 + #3999]" stored at tool "#3999
			else
				errmsg "Tool did not contact plate"
			endif
        endif
	else
		 errmsg "Can't run tool measurement in simulation"
    endif
endsub

sub set_plate_pos
	 if [[#5380==0] and [#5397==0]] ;do this only when not simulating and not rendering
		#4997 = #5071
		#4998 = #5072
		#4999 = #5073
		msg "Probe position set at X:"#4997" Y:"#4998 " Z:"#4999
	 else
		 errmsg "Can't set probe plate position in simulation"
    endif
endsub

sub get_plate_pos
	msg "Probe position at X:"#4997" Y:"#4998 " Z:"#4999
endsub

;#3991 is feature height, #3990 is feature width
sub probe_inside
	 if [[#5380==0] and [#5397==0]] ;do this only when not simulating and not rendering
		gosub find_hole_center
		;switch to probe offset and Zero X and Y than sitch back to spindle 0
		m95
		G10 L20 P1 X0 Y0
		m90
		msg "Measured feature center at X:" #3985 " Y:" #3986 "
	 else
		 errmsg "Can't probe in simulation"
    endif
endsub

;#3991 is box height, #3990 is box width
sub probe_outside
	 if [[#5380==0] and [#5397==0]] ;do this only when not simulating and not rendering
		gosub find_box_center
		;switch to probe offset and Zero X and Y than sitch back to spindle 0
		m95
		G10 L20 P1 X0 Y0
		m90
		msg "Measured box center at X:" #3985 " Y:" #3986 "
	 else
		 errmsg "Can't probe in simulation"
    endif
endsub

sub calibrate_probe
	 if [[#5380==0] and [#5397==0]] ;do this only when not simulating and not rendering
		gosub find_hole_center
		M95 Q1 ;set probe offset
	 else
		 errmsg "Can't probe in simulation"
    endif
endsub

sub find_hole_center
 if [[#5380==0] and [#5397==0]] ;do this only when not simulating and not rendering
		;store machine pos as aprox hole center
		#3992 = #5071	;x
		#3993 = #5072	;y
		#3994 = #5073	;z

		;Probe X+********************************************************
		;go to aprox hole center 
		g0 g53 x#3992 y#3993 z#3994 
		;Probe move in X+ 
		g38.2 g91 X[#3990 + 10] f#4970
		g90
		if [#5067 == 1]	;if probe touched
			#3980 = #5051 ;save X+ result
		else
			msg "probe did not contact"
		endif

		;Probe X-********************************************************
		;go to aprox hole center 
		g0 g53 x#3992 y#3993 z#3994 
		;Probe move in X- 
		g38.2 g91 X[-#3990 - 10] f#4970
		g90
		if [#5067 == 1]	;if probe touched
			#3985 = [[#3980 + #5051]/2] ;save X hole center
		else
			msg "probe did not contact"
		endif

		;Probe Y+********************************************************
		;go back to hole center using probed X
		g0 g53 x#3985 y#3993 z#3994
		;Probe move in Y+ 
		g38.2 g91 Y[#3991 + 10] f#4970
		g90
		if [#5067 == 1]	;if probe touched
			#3981 = #5052 ;save Y+ result
		else
			msg "probe did not contact"
		endif

		;Probe Y-*********************************************************
		;go back to hole center using probed X
		g0 g53 x#3985 y#3993 z#3994 
		;Probe move in Y- 
		g38.2 g91 Y[-#3991 - 10] f#4970
		g90
		if [#5067 == 1]	;if probe touched
			#3986 = [[#3981 + #5052]/2] ;save Y hole center
		else
			msg "probe did not contact"
		endif

		;******************************************************************
		;go back to hole center using probed X and y
		g0 g53 x#3985 y#3986 z#3994
	 else
		 errmsg "Can't probe in simulation"
    endif
endsub

sub find_box_center
 if [[#5380==0] and [#5397==0]] ;do this only when not simulating and not rendering
		;store machine pos as aprox box center and save z
		#3992 = #5071	;x
		#3993 = #5072	;y
		#3994 = #5073	;z
		#3996 = [#3994 - 5]	;Probe z

		;Probe X+********************************************************
		;go to box X+ area
		g0 g53 x[#3992 + #3990 + 10]
		g0 g53 z#3996; lower z
		;Probe move for X+ 
		g38.2 g91 X-20 f#4970
		g90
		if [#5067 == 1]	;if probe touched
			#3980 = #5051 ;save X+ result
		else
			msg "probe did not contact"
		endif
		g0 g53 x[#3992 + #3990 + 10];back off
		g0 g53 z#3994; rise z to save height

		;Probe X-********************************************************
		;go to box X- area
		g0 g53 x[#3992 - #3990 - 10]
		g0 g53 z#3996; lower z
		;Probe move for X- 
		g38.2 g91 X20 f#4970
		g90
		if [#5067 == 1]	;if probe touched
			#3985 = [[#3980 + #5051]/2] ;save X box center
		else
			msg "probe did not contact"
		endif
		g0 g53 x[#3992 - #3990 - 10];back off
		g0 g53 z#3994; rise z to save height

		;Probe Y+********************************************************
		;go back to box center using probed X
		g0 g53 x#3985 y#3993 z#3994
		;go to box Y+ area
		g0 g53 y[#3993 + #3991 + 10]
		g0 g53 z#3996; lower z
		;Probe move for Y+ 
		g38.2 g91 Y-20 f#4970
		g90
		if [#5067 == 1]	;if probe touched
			#3981 = #5052 ;save Y+ result
		else
			msg "probe did not contact"
		endif
		g0 g53 y[#3993 + #3991 + 10];back off
		g0 g53 z#3994; rise z to save height

		;Probe Y-*********************************************************
		;go to box Y- area
		g0 g53 y[#3993 - #3991 - 10]
		g0 g53 z#3996; lower z
		;Probe move for Y- 
		g38.2 g91 Y20 f#4970
		g90
		if [#5067 == 1]	;if probe touched
			#3986 = [[#3981 + #5052]/2] ;save Y box center
		else
			msg "probe did not contact"
		endif
		g0 g53 y[#3993 - #3991 - 10];back off
		g0 g53 z#3994; rise z to save height

		;******************************************************************
		;go back to box center using probed X and y
		g0 g53 x#3985 y#3986 z#3994
	 else
		 errmsg "Can't probe in simulation"
    endif
endsub

;*#4980 is return angle
;*#4981 is probe feed
;*#4982 is probedistX
;*#4983 is probedistY
sub probe_angle
	if [[#5380==0] and [#5397==0]] ;do this only when not simulating and not rendering
		;store save location
		#3992 = #5071	;x
		#3993 = #5072	;y
		#3994 = #5073	;z

		;Probe Point1********************************************************
		;Probe move1 in Y+ 
		g38.2 g91 Y#4983 f#4972
		g90
		if [#5067 == 1]	;if probe touched
			#3961 = #5051 ;save x1 result
			#3962 = #5052 ;save y1 result
		else
			msg "probe did not contact"
		endif
		;go to back save point1
		g0 g53 x#3992 y#3993 z#3994 

		;Probe Point1********************************************************
		;go to save point2
		g0 g53 x[#3992 + #4982] y#3993 z#3994 
		;Probe move2 in Y+ 
		g38.2 g91 Y#4983 f#4972
		g90
		if [#5067 == 1]	;if probe touched
			#3971 = #5051 ;save x2 result
			#3972 = #5052 ;save y2 result
		else
			msg "probe did not contact"
		endif
		;go to back save point2
		g0 g53 x[#3992 + #4982] y#3993 z#3994
		;go to back save point1
		g0 g53 x#3992 y#3993 z#3994 

		#4980 = ATAN[#3972 - #3962]/[#3971 - #3961]	;get angle
		msg "Measured angle at " #4980
	else
		errmsg "Can't probe in simulation"
	endif
endsub