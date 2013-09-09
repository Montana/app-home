module Halo4::GameHistoryHelper

	def update_pagination(current_page, direction)
		if direction == 'older'
			return current_page if current_page == 0
			return current_page - 1
		elsif direction == 'newer'
			return current_page + 1
		end
	end

	def duration_to_friendly(duration)
		str = ''
		
		# Hours
		unless duration.hour == 0
			str += duration.hour.to_s + ' Hour, ' if duration.hour == 1
			str += duration.hour.to_s + ' Hours, ' if duration.hour > 1 || duration.hour < 1
		end

		# Minutes
		unless duration.min == 0
			str += duration.min.to_s + ' Minute, ' if duration.min == 1
			str += duration.min.to_s + ' Minutes, ' if duration.min > 1 || duration.min < 1
		end

		# Seconds
		unless duration.sec == 0
			str += 'and ' + duration.sec.to_s + ' Second' if duration.sec == 1
			str += 'and ' + duration.sec.to_s + ' Seconds' if duration.sec > 1 || duration.sec < 1
		end

		return str
	end

end