test:
	eval $$(cat .env | xargs) dotnet test
	
new_day:
	@touch inputs/Day$(DAY).txt
	@touch inputs/Day$(DAY)_test.txt
	@cp Day01.cs Day$(DAY).cs
	@cp tests/Day01Tests.cs tests/Day$(DAY)Tests.cs
	@sed -i 's/Day01/Day$(DAY)/g' Day$(DAY).cs
	@sed -i 's/Day01/Day$(DAY)/g' tests/Day$(DAY)Tests.cs
	@sed -i 's/DAY01/DAY$(DAY)/g' tests/Day$(DAY)Tests.cs