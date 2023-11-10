// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

import {Component, EventEmitter, OnInit, Output, ViewChild} from '@angular/core';
import {HttpErrorResponse} from '@angular/common/http';
import {NgForm} from '@angular/forms';

import {AlertService, MessageSeverity} from '../../services/alert.service';
import {AccountService} from '../../services/account.service';
import {Role} from '../../models/role.model';
import {Permission} from '../../models/permission.model';


@Component({
  selector: 'app-role-editor',
  templateUrl: './role-editor.component.html',
  styleUrls: ['./role-editor.component.scss']
})
export class RoleEditorComponent implements OnInit {
  public isSaving = false;
  public showValidationErrors = true;
  public roleEdit = new Role();
  public allPermissions: Permission[] = [];
  public selectedValues: { [key: string]: boolean; } = {};
  public formResetToggle = true;
  public changesSavedCallback: { (): void } | undefined;
  public changesFailedCallback: { (): void } | undefined;
  public changesCancelledCallback: { (): void } | undefined;
  // Outupt to broadcast this instance so it can be accessible from within ng-bootstrap modal template
  @Output()
  afterOnInit = new EventEmitter<RoleEditorComponent>();
  private isNewRole = false;
  private editingRoleName: string | null = null;
  @ViewChild('f')
  private form!: NgForm;

  constructor(private alertService: AlertService, private accountService: AccountService) {
  }

  get canManageRoles() {
    return this.accountService.userHasPermission(Permission.manageRoles);
  }

  ngOnInit() {
    this.afterOnInit.emit(this);
  }

  showErrorAlert(caption: string, message: string) {
    this.alertService.showMessage(caption, message, MessageSeverity.error);
  }

  save() {
    this.isSaving = true;
    this.alertService.startLoadingMessage('Saving changes...');

    this.roleEdit.permissions = this.getSelectedPermissions();

    if (this.isNewRole) {
      this.accountService.newRole(this.roleEdit)
        .subscribe({next: role => this.saveSuccessHelper(role), error: error => this.saveFailedHelper(error)});
    } else {
      this.accountService.updateRole(this.roleEdit)
        .subscribe({next: () => this.saveSuccessHelper(), error: error => this.saveFailedHelper(error)});
    }
  }

  cancel() {
    this.roleEdit = new Role();

    this.showValidationErrors = false;
    this.resetForm();

    this.alertService.showMessage('Cancelled', 'Operation cancelled by user', MessageSeverity.default);
    this.alertService.resetStickyMessage();

    if (this.changesCancelledCallback) {
      this.changesCancelledCallback();
    }
  }

  selectAll() {
    this.allPermissions.forEach(p => this.selectedValues[p.value] = true);
  }

  selectNone() {
    this.allPermissions.forEach(p => this.selectedValues[p.value] = false);
  }

  toggleGroup(groupName: string) {
    let firstMemberValue: boolean;

    this.allPermissions.forEach(p => {
      if (p.groupName !== groupName) {
        return;
      }

      if (firstMemberValue == null) {
        firstMemberValue = this.selectedValues[p.value] === true;
      }

      this.selectedValues[p.value] = !firstMemberValue;
    });
  }

  resetForm(replace = false) {
    if (!replace) {
      this.form.reset();
    } else {
      this.formResetToggle = false;

      setTimeout(() => {
        this.formResetToggle = true;
      });
    }
  }

  newRole(allPermissions: Permission[]) {
    this.isNewRole = true;
    this.showValidationErrors = true;

    this.editingRoleName = null;
    this.allPermissions = allPermissions;
    this.selectedValues = {};
    this.roleEdit = new Role();

    return this.roleEdit;
  }

  editRole(role: Role, allPermissions: Permission[]) {
    if (role) {
      this.isNewRole = false;
      this.showValidationErrors = true;

      this.editingRoleName = role.name;
      this.allPermissions = allPermissions;
      this.selectedValues = {};
      role.permissions.forEach(p => this.selectedValues[p.value] = true);
      this.roleEdit = new Role();
      Object.assign(this.roleEdit, role);

      return this.roleEdit;
    } else {
      return this.newRole(allPermissions);
    }
  }

  private saveSuccessHelper(role?: Role) {
    if (role) {
      Object.assign(this.roleEdit, role);
    }

    this.isSaving = false;
    this.alertService.stopLoadingMessage();
    this.showValidationErrors = false;

    if (this.isNewRole) {
      this.alertService.showMessage('Success', `Role "${this.roleEdit.name}" was created successfully`, MessageSeverity.success);
    } else {
      this.alertService.showMessage('Success', `Changes to role "${this.roleEdit.name}" was saved successfully`, MessageSeverity.success);
    }

    this.roleEdit = new Role();
    this.resetForm();

    if (!this.isNewRole && this.accountService.currentUser?.roles.some(r => r === this.editingRoleName)) {
      this.refreshLoggedInUser();
    }

    if (this.changesSavedCallback) {
      this.changesSavedCallback();
    }
  }

  private refreshLoggedInUser() {
    this.accountService.refreshLoggedInUser()
      .subscribe({
        error: error => {
          this.alertService.resetStickyMessage();
          this.alertService.showStickyMessage('Refresh failed', 'An error occurred whilst refreshing logged in user information from the server', MessageSeverity.error, error);
        }
      });
  }

  private saveFailedHelper(error: HttpErrorResponse) {
    this.isSaving = false;
    this.alertService.stopLoadingMessage();
    this.alertService.showStickyMessage('Save Error', 'The below errors occurred whilst saving your changes:', MessageSeverity.error, error);
    this.alertService.showStickyMessage(error, null, MessageSeverity.error);

    if (this.changesFailedCallback) {
      this.changesFailedCallback();
    }
  }

  private getSelectedPermissions() {
    return this.allPermissions.filter(p => this.selectedValues[p.value] === true);
  }
}
