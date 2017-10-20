import { Component, OnInit } from "@angular/core";
import { IProject } from "../../../model/project-interface";
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../../../services/data.service';

@Component({
    templateUrl: './project-details.component.html'
})
export class ProjectDetailsComponent implements OnInit {
    operationText: string = 'Insert';
    errorMessage: string;

    model: IProject = {
        name: ''
    }

    constructor(private router: Router,
        private route: ActivatedRoute,
        private dataService: DataService) { }

    ngOnInit() {
        let id = this.route.snapshot.params['id'];
        if (id !== '0') {
            this.operationText = 'Update';
            this.getProject(id);
        }
    }

    getProject(id: string) {
        this.dataService.getProject(id)
            .subscribe((project: IProject) => {
                this.model = project;
            },
            (err: any) => console.log(err));
    }

    submit() {

        if (this.model.id) {

            this.dataService.updateProject(this.model)
                .subscribe((project: IProject) => {
                    if (project) {
                        this.router.navigate(['/projects']);
                    } else {
                        this.errorMessage = 'Unable to save project';
                    }
                },
                (err: any) => console.log(err));

        } else {
            this.dataService.insertProject(this.model)
                .subscribe((project: IProject) => {
                    if (project) {
                        this.router.navigate(['/projects']);
                    }
                    else {
                        this.errorMessage = 'Unable to add project';
                    }
                },
                (err: any) => console.log(err));
        }
    }

    cancel(event: Event) {
        event.preventDefault();
        this.router.navigate(['/projects']);
    }
}